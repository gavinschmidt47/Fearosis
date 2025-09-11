using UnityEngine;

public class Fear : Point
{
    //Communication with other point scripts
    [SerializeField]
    private Notoriety notoriety;
    [SerializeField]
    private Prejudice prejudice;

    //Portion of Fear points to send to Notoriety and Prejudice
    private float curNVal; //base notoriety value
    private float curPVal; //base prejudice value

    [Range(0f, 1f)]
    public float notorietyModifier;

    [Range(0f, 1f)]
    public float prejudiceModifier;

    public void Start() //sets starting values for notoriety/prejudice
    {
        curNVal = notorietyModifier;
        curPVal = prejudiceModifier;
    }

    public void OnValidate() //keeps the values linked
    {
        if (notorietyModifier != curNVal) //notoriety, change prejudice
        {
            prejudiceModifier = (1 - notorietyModifier); //adjust the prejudice modifier 
            curNVal = notorietyModifier;
            curPVal = prejudiceModifier; //reset the base value to stop checking and adjusting
        }
        
        else if (prejudiceModifier != curPVal) //prejudice, change notoriety
        {
            notorietyModifier = (1 - prejudiceModifier); //adjust the prejudice modifier 
            curPVal = prejudiceModifier;
            curNVal = notorietyModifier; //reset the base value to stop checking and adjusting
        } 

    }

    //Gain Fear points from various sources
    public override void GainPoints(int pointsToGain, string source)
    {
        //Do normal point gain
        base.GainPoints(pointsToGain, source);

        //Distribute a portion of Fear points to Notoriety and Prejudice
        SendNotoriety(pointsToGain, source);
        SendPrejudice(pointsToGain, source);
    }

    //Send a portion of Fear points to Notoriety
    private void SendNotoriety(int pointsFromFear, string source)
    {
        notoriety.GainPoints(GetModifiedPoints(pointsFromFear, notorietyModifier), source);
    }
    //Send a portion of Fear points to Prejudice
    private void SendPrejudice(int pointsFromFear, string source)
    {
        prejudice.GainPoints(GetModifiedPoints(pointsFromFear, prejudiceModifier), source);
    }
}
