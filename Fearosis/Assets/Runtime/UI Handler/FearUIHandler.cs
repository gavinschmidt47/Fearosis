using UnityEngine;
using UnityEngine.UI;

public class FearUIHandler : MonoBehaviour
{
    //Reference to Fear script to get total points
    private Fear fearScript;

    //UI Elements
    [SerializeField]
    private Slider fearSlider;

    private void Start()
    {
        //Find Fear script in scene
        fearScript = FindAnyObjectByType<Fear>();
    }

    //Called from Unity Event in Point.cs when points are gained
    public void UpdateFearUI()
    {
        if (fearSlider != null && fearScript != null)
        {
            fearSlider.value = fearScript.GetTotalPoints();
        }
    }
}
