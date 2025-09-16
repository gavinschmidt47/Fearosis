using UnityEngine;

public class Fear : Point
{
    //Communication with other point scripts
    [SerializeField]
    private Notoriety notoriety;
    [SerializeField]
    private Prejudice prejudice;

    //Percent of Fear points gained to send to Notoriety and Prejudice
    [Range(0f, 1f)]
    public float notorietyModifier;
    [Range(0f, 1f)]
    public float prejudiceModifier;

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
