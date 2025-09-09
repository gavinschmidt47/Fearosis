using UnityEngine;
using System.Collections.Generic;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    private string upgradeName;
    [SerializeField]
    private string upgradeDescription;
    [SerializeField]
    private int fearBuff;
    [SerializeField]
    private int notorietyBuff;
    [SerializeField]
    private int prejudiceBuff;
    [SerializeField]
    private int painBuff;

    private enum SourceType
    {
        Blood,
        Physical,
        Behavior,
        Psychological
    };
    [SerializeField]
    private SourceType source;

    private Fear fearScript;
    private Notoriety notorietyScript;
    private Prejudice prejudiceScript;
    private Pain painScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fearScript = FindAnyObjectByType<Fear>();
        notorietyScript = FindAnyObjectByType<Notoriety>();
        prejudiceScript = FindAnyObjectByType<Prejudice>();
        painScript = FindAnyObjectByType<Pain>();
    }

    public void ApplyUpgrade()
    {
        if (fearBuff > 0)
        {
            fearScript.GainPoints(fearBuff, ((byte)source).ToString());
        }
        if (notorietyBuff > 0)
        {
            notorietyScript.GainPoints(notorietyBuff, ((byte)source).ToString());
        }
        if (prejudiceBuff > 0)
        {
            prejudiceScript.GainPoints(prejudiceBuff, ((byte)source).ToString());
        }
        if (painBuff > 0)
        {
            painScript.GainPoints(painBuff, ((byte)source).ToString());
        }
    }
}
