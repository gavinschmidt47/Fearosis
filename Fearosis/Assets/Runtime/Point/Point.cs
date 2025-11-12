using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour
{
    //Total of all points
    public int numPointsTotal;
    //Starting points from defining trait
    public int numPointsStart;

    //Points gained today
    public int numPointsGainedToday;

    //Points from modifiable sources
    public int numPointsFromBlood;
    public int numPointsFromPhysical;
    public int numPointsFromBehavior;
    public int numPointsFromPsychological;

    //Event modifiers
    public float eventStatModifier;
    public float eventBloodModifier;
    public float eventPhysicalModifier;
    public float eventBehaviorModifier;
    public float eventPsychologicalModifier;

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
