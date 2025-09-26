using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatUIHandler : MonoBehaviour
{
    //UI Text elements for stats
    [SerializeField]
    private TextMeshProUGUI populationText;
    [SerializeField]
    private TextMeshProUGUI infectedText;
    [SerializeField]
    private TextMeshProUGUI fearText;
    [SerializeField]
    private TextMeshProUGUI notorietyText;
    [SerializeField]
    private TextMeshProUGUI prejudiceText;
    [SerializeField]
    private TextMeshProUGUI painText;
    
    //Stat objects
    private Fear fear;
    private Notoriety notoriety;
    private Prejudice prejudice;
    private Pain pain;
    private Infection infection;

    private void Awake()
    {
        //Find the stat objects in the scene
        fear = FindAnyObjectByType<Fear>();
        notoriety = FindAnyObjectByType<Notoriety>();
        prejudice = FindAnyObjectByType<Prejudice>();
        pain = FindAnyObjectByType<Pain>();
        infection = FindAnyObjectByType<Infection>();
    }


    private void OnEnable()
    {
        //Set population text
        populationText.text = infection.population.ToString();
        //Set infected text
        infectedText.text = $"{infection.infected} / {infection.population}";
        //Set the sliders to current points
        fearText.text = fear.GetTotalPoints().ToString();
        notorietyText.text = notoriety.GetTotalPoints().ToString();
        prejudiceText.text = prejudice.GetTotalPoints().ToString();
        painText.text = pain.GetTotalPoints().ToString();

    }
}
