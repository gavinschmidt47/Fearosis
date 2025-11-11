using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour
{
    //Total of all points
    public int numPointsTotal { get { return numPointsTotal; } set { numPointsTotal = value; } }
    //Starting points from defining trait
    public int numPointsStart { get { return numPointsStart; } set { numPointsStart = value; } }

    //Points gained today
    public int numPointsGainedToday { get { return numPointsGainedToday; } set { numPointsGainedToday = value; } }

    //Points from modifiable sources
    public int numPointsFromBlood { get { return numPointsFromBlood; } set { numPointsFromBlood = value; } }
    public int numPointsFromPhysical { get { return numPointsFromPhysical; } set { numPointsFromPhysical = value; } }
    public int numPointsFromBehavior { get { return numPointsFromBehavior; } set { numPointsFromBehavior = value; } }
    public int numPointsFromPsychological { get { return numPointsFromPsychological; } set { numPointsFromPsychological = value; } }

    //Event modifiers
    public float eventStatModifier { get { return eventStatModifier; } set { eventStatModifier = value; } }

    public float eventBloodModifier { get { return eventBloodModifier; } set { eventBloodModifier = value; } }
    public float eventPhysicalModifier { get { return eventPhysicalModifier; } set { eventPhysicalModifier = value; } }
    public float eventBehaviorModifier { get { return eventBehaviorModifier; } set { eventBehaviorModifier = value; } }
    public float eventPsychologicalModifier { get { return eventPsychologicalModifier; } set { eventPsychologicalModifier = value; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numPointsFromBlood = 0;
        numPointsFromPhysical = 0;
        numPointsFromBehavior = 0;
        numPointsFromPsychological = 0;

        eventStatModifier = 1.0f;
        eventBloodModifier = 1.0f;
        eventPhysicalModifier = 1.0f;
        eventBehaviorModifier = 1.0f;
        eventPsychologicalModifier = 1.0f;

        numPointsTotal = numPointsStart;
    }

    public virtual void GainPoints(int pointsToGain, string source)
    {
        numPointsGainedToday += pointsToGain;

        if (pointsToGain >= 0)
        {
            //Add to source-specific points
            switch (source)
            {
                case "Blood":
                    numPointsFromBlood += pointsToGain;
                    break;
                case "Physical":
                    numPointsFromPhysical += pointsToGain;
                    break;
                case "Behavior":
                    numPointsFromBehavior += pointsToGain;
                    break;
                case "Psychological":
                    numPointsFromPsychological += pointsToGain;
                    break;
                default:
                    Debug.Log("Error: Invalid source for points.");
                    break;
            }
        }
    }

    public void AddStatModifier(float modifier)
    {
        //Add event modifier
        eventStatModifier += modifier;
    }

    public void AddSourceModifier(float modifier, string source)
    {
        //Add event modifier to specific source
        switch (source)
        {
            case "Blood":
                eventBloodModifier += modifier;
                break;
            case "Physical":
                eventPhysicalModifier += modifier;
                break;
            case "Behavior":
                eventBehaviorModifier += modifier;
                break;
            case "Psychological":
                eventPsychologicalModifier += modifier;
                break;
            default:
                Debug.Log("Error: Invalid source for points.");
                break;
        }
    }

    //Math to calculate total points with modifiers
    public int GetTotalPoints()
    {
        numPointsTotal = Mathf.RoundToInt((numPointsFromBlood * eventBloodModifier + numPointsFromPhysical * eventPhysicalModifier + numPointsFromBehavior * eventBehaviorModifier + numPointsFromPsychological * eventPsychologicalModifier) * eventStatModifier) + numPointsStart;
        return numPointsTotal;
    }

    //Helper function to apply modifier and round to nearest integer
    public int GetModifiedPoints(int basePoints, float modifier)
    {
        return Mathf.RoundToInt(basePoints * modifier);
    }

    public int GetPointsGainedToday()
    {
        return numPointsGainedToday;
    }
    
    public void ErasePointsGainedToday()
    {
        numPointsGainedToday = 0;
    }
}
