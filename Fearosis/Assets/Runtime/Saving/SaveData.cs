using MemoryPack;
using System.Collections.Generic;

[MemoryPackable]
public partial class SaveData
{
    public int influencePoints;

    public int infected;
    public int population;
    public int dead;
    public int hunters;
    public int round;

    public int fearPointsTotal;
    public int fearPointsStart;
    public int fearPointsGainedToday;
    public int fearPointsFromBlood;
    public int fearPointsFromPhysical;
    public int fearPointsFromBehavior;
    public int fearPointsFromPsychological;
    public float fearEventStatModifier;
    public float fearEventBloodModifier;
    public float fearEventPhysicalModifier;
    public float fearEventBehaviorModifier;
    public float fearEventPsychologicalModifier;

    public int notorietyPointsTotal;
    public int notorietyPointsStart;
    public int notorietyPointsGainedToday;
    public int notorietyPointsFromBlood;
    public int notorietyPointsFromPhysical;
    public int notorietyPointsFromBehavior;
    public int notorietyPointsFromPsychological;
    public float notorietyEventStatModifier;
    public float notorietyEventBloodModifier;
    public float notorietyEventPhysicalModifier;
    public float notorietyEventBehaviorModifier;
    public float notorietyEventPsychologicalModifier;

    public int prejudicePointsTotal;
    public int prejudicePointsStart;
    public int prejudicePointsGainedToday;
    public int prejudicePointsFromBlood;
    public int prejudicePointsFromPhysical;
    public int prejudicePointsFromBehavior;
    public int prejudicePointsFromPsychological;
    public float prejudiceEventStatModifier;
    public float prejudiceEventBloodModifier;
    public float prejudiceEventPhysicalModifier;
    public float prejudiceEventBehaviorModifier;
    public float prejudiceEventPsychologicalModifier;

    public int painPointsTotal;
    public int painPointsStart;
    public int painPointsGainedToday;
    public int painPointsFromBlood;
    public int painPointsFromPhysical;
    public int painPointsFromBehavior;
    public int painPointsFromPsychological;
    public float painEventStatModifier;
    public float painEventBloodModifier;
    public float painEventPhysicalModifier;
    public float painEventBehaviorModifier;
    public float painEventPsychologicalModifier;

    public List<Event> unusedEvents;

    public List<Upgrade> purchasedUpgrades;

    public float infectionRate;
    public float populationInfluenceModifier;
    public int hunterThreshold;
    public int huntersPerThreshold;
    public int painThreshold;
    public int numInfectedToGain;
    public int numInfluenceToGain;

    [MemoryPackConstructor]
    public SaveData() { }
}
