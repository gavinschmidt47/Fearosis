using UnityEngine;
using UnityEngine.UI;

public class NotorietyUIHandler : MonoBehaviour
{
    //Reference to Notoriety script to get total points
    private Notoriety notorietyScript;

    //UI Elements
    [SerializeField]
    private Slider notorietySlider;

    private void Start()
    {
        //Find Notoriety script in scene
        notorietyScript = FindAnyObjectByType<Notoriety>();
    }

    //Called from Unity Event in Point.cs when points are gained
    public void UpdateNotorietyUI()
    {
        if (notorietySlider != null && notorietyScript != null)
        {
            notorietySlider.value = notorietyScript.GetTotalPoints();
        }
    }
}
