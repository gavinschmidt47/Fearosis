using UnityEngine;

public class Event : MonoBehaviour
{
    //Necessary event info
    [SerializeField]
    private string eventName;
    [SerializeField]
    private string eventDescription;
    [SerializeField]
    private float modBuff;

    //Does the event target a specific source or stat. Both will target a specific stat from a specific source
    [SerializeField]
    private bool targetsStats;
    [SerializeField]
    private bool targetsSource;
    
    //If targeting, which source/stat to target
    private enum TargetStats
    {
        Fear,
        Notoriety,
        Prejudice,
        Pain
    };
    [SerializeField]
    private TargetStats targetStats;

    private enum TargetSource
    {
        Blood,
        Physical,
        Behavior,
        Psychological
    };
    [SerializeField]
    private TargetSource targetSource;

    //References to stat scripts
    private Fear fearScript;
    private Notoriety notorietyScript;
    private Prejudice prejudiceScript;
    private Pain painScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get references to stat scripts
        fearScript = Object.FindAnyObjectByType<Fear>();
        notorietyScript = Object.FindAnyObjectByType<Notoriety>();
        prejudiceScript = Object.FindAnyObjectByType<Prejudice>();
        painScript = Object.FindAnyObjectByType<Pain>();
    }

    // Update is called once per frame
    public void ApplyEvent()
    {
        //Apply stat modifier from specific source to specific stat
        if (targetsStats && targetsSource)
        {
            switch (targetStats)
            {
                case TargetStats.Fear:
                    fearScript.AddSourceModifier(modBuff, targetSource.ToString());
                    break;
                case TargetStats.Notoriety:
                    notorietyScript.AddSourceModifier(modBuff, targetSource.ToString());
                    break;
                case TargetStats.Prejudice:
                    prejudiceScript.AddSourceModifier(modBuff, targetSource.ToString());
                    break;
                case TargetStats.Pain:
                    painScript.AddSourceModifier(modBuff, targetSource.ToString());
                    break;
                default:
                    Debug.Log("Error: Invalid source for points");
                    break;
            }
        }
        //Apply stat modifier to all stats from specific source
        else if (targetsSource)
        {
            switch (targetSource)
            {
                case TargetSource.Blood:
                    fearScript.AddSourceModifier(modBuff, "Blood");
                    notorietyScript.AddSourceModifier(modBuff, "Blood");
                    prejudiceScript.AddSourceModifier(modBuff, "Blood");
                    painScript.AddSourceModifier(modBuff, "Blood");
                    break;
                case TargetSource.Physical:
                    fearScript.AddSourceModifier(modBuff, "Physical");
                    notorietyScript.AddSourceModifier(modBuff, "Physical");
                    prejudiceScript.AddSourceModifier(modBuff, "Physical");
                    painScript.AddSourceModifier(modBuff, "Physical");
                    break;
                case TargetSource.Behavior:
                    fearScript.AddSourceModifier(modBuff, "Behavior");
                    notorietyScript.AddSourceModifier(modBuff, "Behavior");
                    prejudiceScript.AddSourceModifier(modBuff, "Behavior");
                    painScript.AddSourceModifier(modBuff, "Behavior");
                    break;
                case TargetSource.Psychological:
                    fearScript.AddSourceModifier(modBuff, "Psychological");
                    notorietyScript.AddSourceModifier(modBuff, "Psychological");
                    prejudiceScript.AddSourceModifier(modBuff, "Psychological");
                    painScript.AddSourceModifier(modBuff, "Psychological");
                    break;
                default:
                    Debug.Log("Error: Invalid source for modification");
                    break;
            }
        }
        //Apply stat modifier to specific stat from all sources
        else if (targetsStats)
        {
            switch (targetStats)
            {
                case TargetStats.Fear:
                    fearScript.AddStatModifier(modBuff);
                    break;
                case TargetStats.Notoriety:
                    notorietyScript.AddStatModifier(modBuff);
                    break;
                case TargetStats.Prejudice:
                    prejudiceScript.AddStatModifier(modBuff);
                    break;
                case TargetStats.Pain:
                    painScript.AddStatModifier(modBuff);
                    break;
                default:
                    Debug.Log("Error: Invalid source for points");
                    break;
            }
        }
    }
}
