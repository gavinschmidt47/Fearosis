using UnityEngine;
using System.Collections.Generic;

public class EventHandler : MonoBehaviour
{
    private List<Event> unusedEvents;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unusedEvents = new List<Event>(GetComponentsInChildren<Event>());
    }

    public void PickEvent()
    {
        //Pick random event from unusedEvents array
        int eventIndex = Random.Range(0, unusedEvents.Count);
        unusedEvents[eventIndex].ApplyEvent();

        //Remove event from unusedEvents array
        unusedEvents.RemoveAt(eventIndex);
    }
}
