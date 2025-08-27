using UnityEngine;

public class ITrait : MonoBehaviour
{
    //Properties
    private int pointCost { get; }
    private int baseFear { get; }
    private int baseNotoriety { get; }
    private int basePrejudice { get; }
    private int basePain { get; }

    //Constructors
    public ITrait(int pointCost, int baseFear, int baseNotoriety, int basePrejudice, int basePain)
    {
        this.pointCost = pointCost;
        this.baseFear = baseFear;
        this.baseNotoriety = baseNotoriety;
        this.basePrejudice = basePrejudice;
        this.basePain = basePain;
    }

    //Apply to player function
    
}
