using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatUIHandler : MonoBehaviour
{
    //Sliders to show stats (Will likely be replaced)
    [SerializeField]
    private Slider fearSlider;
    [SerializeField]
    private Slider notorietySlider;
    [SerializeField]
    private Slider prejudiceSlider;
    [SerializeField]
    private Slider painSlider;
    [SerializeField]
    private TextMeshProUGUI infectionText;


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
        //Set the sliders to current points
        fearSlider.value = fear.GetTotalPoints();
        notorietySlider.value = notoriety.GetTotalPoints();
        prejudiceSlider.value = prejudice.GetTotalPoints();
        painSlider.value = pain.GetTotalPoints();

        //Set infection text
        infectionText.text = $"{infection.infected} / {infection.population}";
    }
}
