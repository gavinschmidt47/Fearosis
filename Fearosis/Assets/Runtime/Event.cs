using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField]
    private string eventName;
    [SerializeField]
    private string eventDescription;
    [SerializeField]
    private int modBuff;
    [SerializeField]
    private enum targetSource
    {
        Fear,
        Notoriety,
        Prejudice,
        Pain
    };

    private Fear fearScript;
    private Notoriety notorietyScript;
    private Prejudice prejudiceScript;
    private Pain painScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fearScript = FindAnyObjectOfType<Fear>();
        notorietyScript = FindAnyObjectOfType<Notoriety>();
        prejudiceScript = FindAnyObjectOfType<Prejudice>();
        painScript = FindAnyObjectOfType<Pain>();
    }

    // Update is called once per frame
    public void ApplyEvent()
    {
        switch (targetSource)
        {
            case targetSource.Fear:
                break;
            case targetSource.Notoriety:
                break;
            case targetSource.Prejudice:
                break;
            case targetSource.Pain:
                break;
            default:
                Debug.Log("Error: Invalid source for modification");
                break;
        }
    }
}
