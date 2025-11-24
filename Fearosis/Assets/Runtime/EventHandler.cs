using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System.Xml.Serialization;

public class EventHandler : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField]
    private GameObject eventUI;
    private TextMeshProUGUI eventNameText;
    private TextMeshProUGUI eventDescriptionText;
    private Image eventImage;

    private FullGameStats fullGameStatsScript;
    [HideInInspector]
    public List<Event> unusedEvents;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unusedEvents = new List<Event>(GetComponentsInChildren<Event>());
        fullGameStatsScript = FindAnyObjectByType<FullGameStats>();

        eventUI.SetActive(true); // Temporarily activate to find children
        foreach (Transform child in eventUI.transform)
        {
            switch (child.tag)
            {
                case "Event Name":
                    eventNameText = child.GetComponent<TextMeshProUGUI>();
                    break;
                case "Event Description":
                    eventDescriptionText = child.GetComponent<TextMeshProUGUI>();
                    break;
                case "Event Image":
                    eventImage = child.GetComponent<Image>();
                    break;
                default:
                    break;
            }
        }
        eventUI.SetActive(false);
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
        unusedEvents[eventIndex].ApplyEvent(UpdateUI);

        //Remove event from unusedEvents array
        unusedEvents.RemoveAt(eventIndex);
    }

    private void UpdateUI(string eventName, string eventDescription/*, Sprite eventSprite*/)
    {
        eventUI.SetActive(true);
        eventNameText.text = eventName;
        eventDescriptionText.text = eventDescription;
        //eventImage.sprite = eventSprite;
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
