using UnityEngine;
using UnityEngine.UI;

public class PainUIHandler : MonoBehaviour
{
    //Reference to Pain script to get total points
    private Pain painScript;

    //UI Elements
    [SerializeField]
    private Slider painSlider;

    private void Start()
    {
        //Find Pain script in scene
        painScript = FindAnyObjectByType<Pain>();
    }

    //Called from Unity Event in Point.cs when points are gained
    public void UpdatePainUI()
    {
        if (painSlider != null && painScript != null)
        {
            painSlider.value = painScript.GetTotalPoints();
        }
    }
}
