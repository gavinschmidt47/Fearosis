using UnityEngine;
using UnityEngine.UI;

public class PrejudiceUIHandler : MonoBehaviour
{
    //Reference to Prejudice script to get total points
    private Prejudice prejudiceScript;

    //UI Elements
    [SerializeField]
    private Slider prejudiceSlider;

    private void Start()
    {
        //Find Prejudice script in scene
        prejudiceScript = FindAnyObjectByType<Prejudice>();
    }

    //Called from Unity Event in Point.cs when points are gained
    public void UpdatePrejudiceUI()
    {
        if (prejudiceSlider != null && prejudiceScript != null)
        {
            prejudiceSlider.value = prejudiceScript.GetTotalPoints();
        }
    }
}
