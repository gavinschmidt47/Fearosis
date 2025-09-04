using UnityEngine;

public class Notoriety : Point
{
    [SerializeField]
    private Pain pain;

    //Portion of Notoriety points to send to Pain
    public float painModifier = -0.33f;

    //Gain Notoriety points from various sources
    public override void GainPoints(int pointsToGain, string source)
    {
        //Do normal point gain
        base.GainPoints(pointsToGain, source);

        //Distribute a portion of Notoriety points to Pain
        SendPain(pointsToGain, source);
    }
    
    //Send a portion of Notoriety points to Pain
    private void SendPain(int pointsFromNotoriety, string source)
    {
        pain.GainPoints(GetModifiedPoints(pointsFromNotoriety, painModifier), source);
    }
}
