using UnityEngine;
using UnityEngine.Events;

public class DayHandler : MonoBehaviour
{
    //Infection rate modifier
    [SerializeField]
    private float infectionRate = 1.0f;
    [SerializeField]
    private float populationInfluenceModifier = 1.0f;
    [SerializeField]
    private int hunterThreshold = 15;
    [SerializeField]
    private int huntersPerThreshold = 1;
    [SerializeField]
    private int painThreshold = 20;

    //References to other scripts
    private Fear fearScript;
    private Notoriety notorietyScript;
    private Prejudice prejudiceScript;
    private Pain painScript;
    private Influence influenceScript;
    private FullGameStats fullGameStatsScript;

    //Day-specific variables
    private int numInfectedToGain;
    private int numInfluenceToGain;

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
        numInfectedToGain += Mathf.RoundToInt(numFear + Random.Range(numFear - instability, numFear + instability) * infectionRate);

        //Update full game stats script
        fullGameStatsScript.AddInfected(numInfectedToGain);

        //Calculate hunter kills
        fullGameStatsScript.hunters -= fullGameStatsScript.hunters;

        //Calculate pain kills
        if (numPain >= painThreshold)
        {
            fullGameStatsScript.infected -= numPain - painThreshold;
        }

        //Influence logic
        int populationModifiedInfectionInfluence = Mathf.RoundToInt(numInfectedToGain / populationInfluenceModifier);
        // Ensure at least 1 influence is gained
        if (populationModifiedInfectionInfluence < 1)
        {
            populationModifiedInfectionInfluence = 1;
        }
        numInfluenceToGain = Mathf.RoundToInt(numPain * (numInfectedToGain / populationInfluenceModifier) * numNotoriety);
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
