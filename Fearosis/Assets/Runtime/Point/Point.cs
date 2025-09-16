using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour
{
    //Total of all points
    private int numPointsTotal = 0;
    //Starting points from defining trait
    private int numPointsStart = 0;

    //Points from modifiable sources
    private int numPointsFromBlood = 0;
    private int numPointsFromPhysical = 0;
    private int numPointsFromBehavior = 0;
    private int numPointsFromPsychological = 0;

    //Event modifiers
    private float eventStatModifier = 1.0f;

    private float eventBloodModifier = 1.0f;
    private float eventPhysicalModifier = 1.0f;
    private float eventBehaviorModifier = 1.0f;
    private float eventPsychologicalModifier = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numPointsFromBlood = 0;
        numPointsFromPhysical = 0;
        numPointsFromBehavior = 0;
        numPointsFromPsychological = 0;

        numPointsTotal = numPointsStart;
    }

    

    public virtual void GainPoints(int pointsToGain, string source)
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
}
