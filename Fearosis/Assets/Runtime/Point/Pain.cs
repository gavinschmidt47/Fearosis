using UnityEngine;

public class Pain : Point
{
    [SerializeField]
    private Fear fear;

    [Range(-1f, 0f)]
    public float fearModifier = -0.33f;

    //Gain Pain points from various sources
    public override void GainPoints(int pointsToGain, string source)
    {
        //Do normal point gain
        base.GainPoints(pointsToGain, source);

        //Distribute a portion of Fear points to Notoriety and Prejudice
        SendFear(pointsToGain, source);
    }

    //Send a portion of Fear points to Notoriety
    private void SendFear(int pointsFromPain, string source)
    {
        fear.GainPointsNoSend(GetModifiedPoints(pointsFromPain, fearModifier), source);
    }
}
