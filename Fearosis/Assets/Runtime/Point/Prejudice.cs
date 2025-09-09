using UnityEngine;

public class Prejudice : Point
{
    [SerializeField]
    private Pain pain;

    //Portion of Prejudice points to send to Pain
    [Range(-1f, 0f)]
    public float painModifier = -0.33f;

    //Gain Prejudice points from various sources
    public override void GainPoints(int pointsToGain, string source)
    {
        //Do normal point gain
        base.GainPoints(pointsToGain, source);

        //Distribute a portion of Prejudice points to Pain
        SendPain(pointsToGain, source);
    }

    //Send a portion of Prejudice points to Pain
    private void SendPain(int pointsFromPrejudice, string source)
    {
        pain.GainPoints(GetModifiedPoints(pointsFromPrejudice, painModifier), source);
    }
}
