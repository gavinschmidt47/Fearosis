using UnityEngine;
using System.Collections.Generic;

public class EventHandler : MonoBehaviour
{
    private FullGameStats fullGameStatsScript;
    public List<Event> unusedEvents { get { return unusedEvents; } private set { unusedEvents = value; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unusedEvents = new List<Event>(GetComponentsInChildren<Event>());
        fullGameStatsScript = FindAnyObjectByType<FullGameStats>();
    }

    public void PickEvent()
    {
        int eventsChecked = 0;
        int eventIndex = Random.Range(0, unusedEvents.Count-1);

        //Pick random event from unusedEvents array and reshuffle if it can't trigger
        while (!unusedEvents[eventIndex].CanEventTrigger(fullGameStatsScript.round))
        {
            if (eventsChecked >= unusedEvents.Count)
            {
                unusedEvents.Clear();
                unusedEvents = new List<Event>(GetComponentsInChildren<Event>());
                break;
            }
            eventIndex = Random.Range(0, unusedEvents.Count-1);
            eventsChecked++;
        }
        unusedEvents[eventIndex].ApplyEvent();

        //Remove event from unusedEvents array
        unusedEvents.RemoveAt(eventIndex);
    }

    public void RepopulateUnusedEvents(List<Event> loadedList)
    {
        unusedEvents.Clear();
        foreach (Event curEvent in loadedList)
        {
            unusedEvents.Add(curEvent);
        }
    }

}
