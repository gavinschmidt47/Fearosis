using UnityEngine;
using UnityEngine.Events;

public class DayHandler : MonoBehaviour
{
    //Infection rate modifier
    [SerializeField]
    public float infectionRate { get { return infectionRate; } set { infectionRate = value; } }
    [SerializeField]
    public float populationInfluenceModifier { get { return populationInfluenceModifier; } set { populationInfluenceModifier = value; } }
    [SerializeField]
    public int hunterThreshold { get { return hunterThreshold; } set { hunterThreshold = value; } }
    [SerializeField]
    public int huntersPerThreshold { get { return huntersPerThreshold; } set { huntersPerThreshold = value; } }
    [SerializeField]
    public int painThreshold { get { return painThreshold; } set { painThreshold = value; } }

    //References to other scripts
    private Fear fearScript;
    private Notoriety notorietyScript;
    private Prejudice prejudiceScript;
    private Pain painScript;
    private Influence influenceScript;
    private FullGameStats fullGameStatsScript;

    //Day-specific variables
    public int numInfectedToGain { get; set; }
    public int numInfluenceToGain { get; set; }

    //Unity event on day start
    public UnityEvent dayStartEvent = new UnityEvent();

    public void Start()
    {
        //Initialize references and variables
        fearScript = FindAnyObjectByType<Fear>();
        notorietyScript = FindAnyObjectByType<Notoriety>();
        prejudiceScript = FindAnyObjectByType<Prejudice>();
        painScript = FindAnyObjectByType<Pain>();
        influenceScript = FindAnyObjectByType<Influence>();
        fullGameStatsScript = FindAnyObjectByType<FullGameStats>();
        numInfectedToGain = 0;
    }

    public void OnNextDay()
    {
        //Get stats
        int numFear = fearScript.GetTotalPoints();
        int numNotoriety = notorietyScript.GetTotalPoints();
        int numPrejudice = prejudiceScript.GetTotalPoints();
        int numPain = painScript.GetTotalPoints();
        int instability = Mathf.Abs(numNotoriety - numPrejudice);

        //Calculate new infections
        numInfectedToGain += Mathf.RoundToInt(numFear + Random.Range(Mathf.Max(numFear - instability, 0), numFear + instability) * infectionRate);

        //Update full game stats script
        Debug.Log($"Infected to gain: {numInfectedToGain}");
        fullGameStatsScript.AddInfected(numInfectedToGain);

        //Calculate hunter kills
        fullGameStatsScript.KillInfected(fullGameStatsScript.hunters);

        //Calculate pain kills
        if (numPain >= painThreshold)
        {
            fullGameStatsScript.KillInfected(numPain - painThreshold);
        }

        //Influence logic
        int populationModifiedInfectionInfluence = Mathf.Max(Mathf.RoundToInt(numInfectedToGain / populationInfluenceModifier), 1);
        Debug.Log($"Population modified infection influence: {populationModifiedInfectionInfluence}");
        numInfluenceToGain = Mathf.Max(Mathf.RoundToInt(numPain*.67f + populationModifiedInfectionInfluence + Mathf.Max(numNotoriety*.50f, 1)), 5);
        influenceScript.influencePoints += numInfluenceToGain;

        //Hunter logic
        if (instability > hunterThreshold)
        {
            int numHuntersToAdd = instability * huntersPerThreshold;
            fullGameStatsScript.hunters += numHuntersToAdd;
        }

        //Call day start event
        dayStartEvent.Invoke();
    }
}
