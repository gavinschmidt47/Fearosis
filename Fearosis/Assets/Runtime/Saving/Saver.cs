using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Saver : MonoBehaviour
{
    public string sceneName;

    private Influence influenceScript;
    private int influencePoints;

    private FullGameStats fullGameStatsScript;
    private int infected;
    private int population;
    private int dead;
    private int hunters;
    private int round;

    private Fear fearScript;
    private int fearPointsTotal;
    private int fearPointsStart;
    private int fearPointsGainedToday;
    private int fearPointsFromBlood;
    private int fearPointsFromPhysical;
    private int fearPointsFromBehavior;
    private int fearPointsFromPsychological;
    private float fearEventStatModifier;
    private float fearEventBloodModifier;
    private float fearEventPhysicalModifier;
    private float fearEventBehaviorModifier;
    private float fearEventPsychologicalModifier;

    private Notoriety notorietyScript;
    private int notorietyPointsTotal;
    private int notorietyPointsStart;
    private int notorietyPointsGainedToday;
    private int notorietyPointsFromBlood;
    private int notorietyPointsFromPhysical;
    private int notorietyPointsFromBehavior;
    private int notorietyPointsFromPsychological;
    private float notorietyEventStatModifier;
    private float notorietyEventBloodModifier;
    private float notorietyEventPhysicalModifier;
    private float notorietyEventBehaviorModifier;
    private float notorietyEventPsychologicalModifier;

    private Prejudice prejudiceScript;
    private int prejudicePointsTotal;
    private int prejudicePointsStart;
    private int prejudicePointsGainedToday;
    private int prejudicePointsFromBlood;
    private int prejudicePointsFromPhysical;
    private int prejudicePointsFromBehavior;
    private int prejudicePointsFromPsychological;
    private float prejudiceEventStatModifier;
    private float prejudiceEventBloodModifier;
    private float prejudiceEventPhysicalModifier;
    private float prejudiceEventBehaviorModifier;
    private float prejudiceEventPsychologicalModifier;

    private Pain painScript;
    private int painPointsTotal;
    private int painPointsStart;
    private int painPointsGainedToday;
    private int painPointsFromBlood;
    private int painPointsFromPhysical;
    private int painPointsFromBehavior;
    private int painPointsFromPsychological;
    private float painEventStatModifier;
    private float painEventBloodModifier;
    private float painEventPhysicalModifier;
    private float painEventBehaviorModifier;
    private float painEventPsychologicalModifier;

    private EventHandler eventHandlerScript;
    private List<Event> unusedEvents;

    private CollectUpgrades collectUpgradesScript;
    private List<Upgrade> purchasedUpgrades;

    private DayHandler dayHandlerScript;
    private float infectionRate;
    private float populationInfluenceModifier;
    private int hunterThreshold;
    private int huntersPerThreshold;
    private int painThreshold;
    private int numInfectedToGain;
    private int numInfluenceToGain;

    private SaveSystem saveSystem;

    void Start()
    {
        influenceScript = FindAnyObjectByType<Influence>();
        fullGameStatsScript = FindAnyObjectByType<FullGameStats>();
        fearScript = FindAnyObjectByType<Fear>();
        notorietyScript = FindAnyObjectByType<Notoriety>();
        prejudiceScript = FindAnyObjectByType<Prejudice>();
        painScript = FindAnyObjectByType<Pain>();
        eventHandlerScript = FindAnyObjectByType<EventHandler>();
        collectUpgradesScript = FindAnyObjectByType<CollectUpgrades>();
        dayHandlerScript = FindAnyObjectByType<DayHandler>();
        saveSystem = GetComponent<SaveSystem>();

    }

    public SaveData GetSaveableObject()
    {
        CollectData();

        SaveData saveData = new SaveData();

        saveData.sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        
        saveData.influencePoints = influencePoints;
        saveData.infected = infected;
        saveData.population = population;
        saveData.dead = dead;
        saveData.hunters = hunters;
        saveData.round = round;

        saveData.fearPointsTotal = fearPointsTotal;
        saveData.fearPointsStart = fearPointsStart;
        saveData.fearPointsGainedToday = fearPointsGainedToday;
        saveData.fearPointsFromBlood = fearPointsFromBlood;
        saveData.fearPointsFromPhysical = fearPointsFromPhysical;
        saveData.fearPointsFromBehavior = fearPointsFromBehavior;
        saveData.fearPointsFromPsychological = fearPointsFromPsychological;
        saveData.fearEventStatModifier = fearEventStatModifier;
        saveData.fearEventBloodModifier = fearEventBloodModifier;
        saveData.fearEventPhysicalModifier = fearEventPhysicalModifier;
        saveData.fearEventBehaviorModifier = fearEventBehaviorModifier;
        saveData.fearEventPsychologicalModifier = fearEventPsychologicalModifier;

        saveData.notorietyPointsTotal = notorietyPointsTotal;
        saveData.notorietyPointsStart = notorietyPointsStart;
        saveData.notorietyPointsGainedToday = notorietyPointsGainedToday;
        saveData.notorietyPointsFromBlood = notorietyPointsFromBlood;
        saveData.notorietyPointsFromPhysical = notorietyPointsFromPhysical;
        saveData.notorietyPointsFromBehavior = notorietyPointsFromBehavior;
        saveData.notorietyPointsFromPsychological = notorietyPointsFromPsychological;
        saveData.notorietyEventStatModifier = notorietyEventStatModifier;
        saveData.notorietyEventBloodModifier = notorietyEventBloodModifier;
        saveData.notorietyEventPhysicalModifier = notorietyEventPhysicalModifier;
        saveData.notorietyEventBehaviorModifier = notorietyEventBehaviorModifier;
        saveData.notorietyEventPsychologicalModifier = notorietyEventPsychologicalModifier;

        saveData.prejudicePointsTotal = prejudicePointsTotal;
        saveData.prejudicePointsStart = prejudicePointsStart;
        saveData.prejudicePointsGainedToday = prejudicePointsGainedToday;
        saveData.prejudicePointsFromBlood = prejudicePointsFromBlood;
        saveData.prejudicePointsFromPhysical = prejudicePointsFromPhysical;
        saveData.prejudicePointsFromBehavior = prejudicePointsFromBehavior;
        saveData.prejudicePointsFromPsychological = prejudicePointsFromPsychological;
        saveData.prejudiceEventStatModifier = prejudiceEventStatModifier;
        saveData.prejudiceEventBloodModifier = prejudiceEventBloodModifier;
        saveData.prejudiceEventPhysicalModifier = prejudiceEventPhysicalModifier;
        saveData.prejudiceEventBehaviorModifier = prejudiceEventBehaviorModifier;
        saveData.prejudiceEventPsychologicalModifier = prejudiceEventPsychologicalModifier;

        saveData.painPointsTotal = painPointsTotal;
        saveData.painPointsStart = painPointsStart;
        saveData.painPointsGainedToday = painPointsGainedToday;
        saveData.painPointsFromBlood = painPointsFromBlood;
        saveData.painPointsFromPhysical = painPointsFromPhysical;
        saveData.painPointsFromBehavior = painPointsFromBehavior;
        saveData.painPointsFromPsychological = painPointsFromPsychological;
        saveData.painEventStatModifier = painEventStatModifier;
        saveData.painEventBloodModifier = painEventBloodModifier;
        saveData.painEventPhysicalModifier = painEventPhysicalModifier;
        saveData.painEventBehaviorModifier = painEventBehaviorModifier;
        saveData.painEventPsychologicalModifier = painEventPsychologicalModifier;

        saveData.unusedEvents = new List<Event>(unusedEvents);
        saveData.purchasedUpgrades = new List<Upgrade>(purchasedUpgrades);

        saveData.infectionRate = infectionRate;
        saveData.populationInfluenceModifier = populationInfluenceModifier;
        saveData.hunterThreshold = hunterThreshold;
        saveData.huntersPerThreshold = huntersPerThreshold;
        saveData.painThreshold = painThreshold;
        saveData.numInfectedToGain = numInfectedToGain;
        saveData.numInfluenceToGain = numInfluenceToGain;

        return saveData;
    }

    private void CollectData()
    {
        influencePoints = influenceScript.influencePoints;

        infected = fullGameStatsScript.infected;
        population = fullGameStatsScript.population;
        dead = fullGameStatsScript.dead;
        hunters = fullGameStatsScript.hunters;
        round = fullGameStatsScript.round;

        fearPointsTotal = fearScript.numPointsTotal;
        fearPointsStart = fearScript.numPointsStart;
        fearPointsGainedToday = fearScript.numPointsGainedToday;
        fearPointsFromBlood = fearScript.numPointsFromBlood;
        fearPointsFromPhysical = fearScript.numPointsFromPhysical;
        fearPointsFromBehavior = fearScript.numPointsFromBehavior;
        fearPointsFromPsychological = fearScript.numPointsFromPsychological;
        fearEventStatModifier = fearScript.eventStatModifier;
        fearEventBloodModifier = fearScript.eventBloodModifier;
        fearEventPhysicalModifier = fearScript.eventPhysicalModifier;
        fearEventBehaviorModifier = fearScript.eventBehaviorModifier;
        fearEventPsychologicalModifier = fearScript.eventPsychologicalModifier;

        notorietyPointsTotal = notorietyScript.numPointsTotal;
        notorietyPointsStart = notorietyScript.numPointsStart;
        notorietyPointsGainedToday = notorietyScript.numPointsGainedToday;
        notorietyPointsFromBlood = notorietyScript.numPointsFromBlood;
        notorietyPointsFromPhysical = notorietyScript.numPointsFromPhysical;
        notorietyPointsFromBehavior = notorietyScript.numPointsFromBehavior;
        notorietyPointsFromPsychological = notorietyScript.numPointsFromPsychological;
        notorietyEventStatModifier = notorietyScript.eventStatModifier;
        notorietyEventBloodModifier = notorietyScript.eventBloodModifier;
        notorietyEventPhysicalModifier = notorietyScript.eventPhysicalModifier;
        notorietyEventBehaviorModifier = notorietyScript.eventBehaviorModifier;
        notorietyEventPsychologicalModifier = notorietyScript.eventPsychologicalModifier;

        prejudicePointsTotal = prejudiceScript.numPointsTotal;
        prejudicePointsStart = prejudiceScript.numPointsStart;
        prejudicePointsGainedToday = prejudiceScript.numPointsGainedToday;
        prejudicePointsFromBlood = prejudiceScript.numPointsFromBlood;
        prejudicePointsFromPhysical = prejudiceScript.numPointsFromPhysical;
        prejudicePointsFromBehavior = prejudiceScript.numPointsFromBehavior;
        prejudicePointsFromPsychological = prejudiceScript.numPointsFromPsychological;
        prejudiceEventStatModifier = prejudiceScript.eventStatModifier;
        prejudiceEventBloodModifier = prejudiceScript.eventBloodModifier;
        prejudiceEventPhysicalModifier = prejudiceScript.eventPhysicalModifier;
        prejudiceEventBehaviorModifier = prejudiceScript.eventBehaviorModifier;
        prejudiceEventPsychologicalModifier = prejudiceScript.eventPsychologicalModifier;

        painPointsTotal = painScript.numPointsTotal;
        painPointsStart = painScript.numPointsStart;
        painPointsGainedToday = painScript.numPointsGainedToday;
        painPointsFromBlood = painScript.numPointsFromBlood;
        painPointsFromPhysical = painScript.numPointsFromPhysical;
        painPointsFromBehavior = painScript.numPointsFromBehavior;
        painPointsFromPsychological = painScript.numPointsFromPsychological;
        painEventStatModifier = painScript.eventStatModifier;
        painEventBloodModifier = painScript.eventBloodModifier;
        painEventPhysicalModifier = painScript.eventPhysicalModifier;
        painEventBehaviorModifier = painScript.eventBehaviorModifier;
        painEventPsychologicalModifier = painScript.eventPsychologicalModifier;

        foreach (Event unusedEvent in eventHandlerScript.unusedEvents)
        {
            unusedEvents.Add(unusedEvent);
        }

        purchasedUpgrades = collectUpgradesScript.CollectPurchasedUpgrades();

        infectionRate = dayHandlerScript.infectionRate;
        populationInfluenceModifier = dayHandlerScript.populationInfluenceModifier;
        hunterThreshold = dayHandlerScript.hunterThreshold;
        huntersPerThreshold = dayHandlerScript.huntersPerThreshold;
        painThreshold = dayHandlerScript.painThreshold;
        numInfectedToGain = dayHandlerScript.numInfectedToGain;
        numInfluenceToGain = dayHandlerScript.numInfluenceToGain;
    }

    public void SaveGame()
    {
        saveSystem.SaveGame(this.GetSaveableObject());
    }
    public void LoadGame()
    {
        var saveData = saveSystem.LoadGame();
        if (saveData != null)
        {
            // Apply loaded data to the game state
            // Implementation depends on the structure of SaveData and game state management
            influenceScript.influencePoints = influencePoints;

            fullGameStatsScript.infected = infected;
            fullGameStatsScript.population = population;
            fullGameStatsScript.dead = dead;
            fullGameStatsScript.hunters = hunters;
            fullGameStatsScript.round = round;

            fearScript.numPointsTotal = fearPointsTotal;
            fearScript.numPointsStart = fearPointsStart;
            fearScript.numPointsGainedToday = fearPointsGainedToday;
            fearScript.numPointsFromBlood = fearPointsFromBlood;
            fearScript.numPointsFromPhysical = fearPointsFromPhysical;
            fearScript.numPointsFromBehavior = fearPointsFromBehavior;
            fearScript.numPointsFromPsychological = fearPointsFromPsychological;
            fearScript.eventStatModifier = fearEventStatModifier;
            fearScript.eventBloodModifier = fearEventBloodModifier;
            fearScript.eventPhysicalModifier = fearEventPhysicalModifier;
            fearScript.eventBehaviorModifier = fearEventBehaviorModifier;
            fearScript.eventPsychologicalModifier = fearEventPsychologicalModifier;

            notorietyScript.numPointsTotal = notorietyPointsTotal;
            notorietyScript.numPointsStart = notorietyPointsStart;
            notorietyScript.numPointsGainedToday = notorietyPointsGainedToday;
            notorietyScript.numPointsFromBlood = notorietyPointsFromBlood;
            notorietyScript.numPointsFromPhysical = notorietyPointsFromPhysical;
            notorietyScript.numPointsFromBehavior = notorietyPointsFromBehavior;
            notorietyScript.numPointsFromPsychological = notorietyPointsFromPsychological;
            notorietyScript.eventStatModifier = notorietyEventStatModifier;
            notorietyScript.eventBloodModifier = notorietyEventBloodModifier;
            notorietyScript.eventPhysicalModifier = notorietyEventPhysicalModifier;
            notorietyScript.eventBehaviorModifier = notorietyEventBehaviorModifier;
            notorietyScript.eventPsychologicalModifier = notorietyEventPsychologicalModifier;

            prejudiceScript.numPointsTotal = prejudicePointsTotal;
            prejudiceScript.numPointsStart = prejudicePointsStart;
            prejudiceScript.numPointsGainedToday = prejudicePointsGainedToday;
            prejudiceScript.numPointsFromBlood = prejudicePointsFromBlood;
            prejudiceScript.numPointsFromPhysical = prejudicePointsFromPhysical;
            prejudiceScript.numPointsFromBehavior = prejudicePointsFromBehavior;
            prejudiceScript.numPointsFromPsychological = prejudicePointsFromPsychological;
            prejudiceScript.eventStatModifier = prejudiceEventStatModifier;
            prejudiceScript.eventBloodModifier = prejudiceEventBloodModifier;
            prejudiceScript.eventPhysicalModifier = prejudiceEventPhysicalModifier;
            prejudiceScript.eventBehaviorModifier = prejudiceEventBehaviorModifier;
            prejudiceScript.eventPsychologicalModifier = prejudiceEventPsychologicalModifier;

            painScript.numPointsTotal = painPointsTotal;
            painScript.numPointsStart = painPointsStart;
            painScript.numPointsGainedToday = painPointsGainedToday;
            painScript.numPointsFromBlood = painPointsFromBlood;
            painScript.numPointsFromPhysical = painPointsFromPhysical;
            painScript.numPointsFromBehavior = painPointsFromBehavior;
            painScript.numPointsFromPsychological = painPointsFromPsychological;
            painScript.eventStatModifier = painEventStatModifier;
            painScript.eventBloodModifier = painEventBloodModifier;
            painScript.eventPhysicalModifier = painEventPhysicalModifier;
            painScript.eventBehaviorModifier = painEventBehaviorModifier;
            painScript.eventPsychologicalModifier = painEventPsychologicalModifier;

            eventHandlerScript.RepopulateUnusedEvents(unusedEvents);

            collectUpgradesScript.ReUpgrade();

            dayHandlerScript.infectionRate = infectionRate;
            dayHandlerScript.populationInfluenceModifier = populationInfluenceModifier;
            dayHandlerScript.hunterThreshold = hunterThreshold;
            dayHandlerScript.huntersPerThreshold = huntersPerThreshold;
            dayHandlerScript.painThreshold = painThreshold;
            dayHandlerScript.numInfectedToGain = numInfectedToGain;
            dayHandlerScript.numInfluenceToGain = numInfluenceToGain;

        }
    }
}