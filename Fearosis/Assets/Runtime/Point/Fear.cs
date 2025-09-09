using UnityEngine;

public class Fear : Point
{
    //Communication with other point scripts
    [SerializeField]
    private Notoriety notoriety;
    [SerializeField]
    private Prejudice prejudice;

    //Portion of Fear points to send to Notoriety and Prejudice
    public float baseNVal; //base notoriety value
    public float basePVal; //base prejudice value

    [Range(-1f, 0f)]
    public float notorietyModifier;

    [Range(0f, 1f)]
    public float prejudiceModifier;

    public void Start() //sets starting values for notoriety/prejudice
    {
        baseNVal = -0.33f; //set starting value here
        notorietyModifier = baseNVal;
        basePVal = 0.67f; //set starting value here
        prejudiceModifier = basePVal;
    }

    public void Update() //keeps the values linked
    {
        if (notorietyModifier != baseNVal) //notoriety, change prejudice
        {
            prejudiceModifier = (1 + notorietyModifier); //adjust the prejudice modifier 
            baseNVal = notorietyModifier;
            basePVal = prejudiceModifier; //reset the base value to stop checking and adjusting
        }
        
        else if (prejudiceModifier != basePVal) //prejudice, change notoriety
        {
            notorietyModifier = (-1 + prejudiceModifier); //adjust the prejudice modifier 
            basePVal = prejudiceModifier;
            baseNVal = notorietyModifier; //reset the base value to stop checking and adjusting
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
