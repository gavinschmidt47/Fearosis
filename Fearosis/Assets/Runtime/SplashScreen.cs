using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Image[] screens;
    public float waitTime = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ShowSplashScreens());
    }

    private IEnumerator ShowSplashScreens()
    {
        foreach (Image screen in screens)
        {
            screen.gameObject.SetActive(true);
            float timer = 0.0f;
            float peakTime = waitTime / 2.0f;
            while (timer < waitTime)
            {
                if (timer > peakTime)
                    screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, Mathf.Lerp(1.0f, 0.0f, (timer - peakTime) / peakTime));
                else
                    screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, Mathf.Lerp(0.0f, 1.0f, timer / peakTime));
                timer += Time.deltaTime;
                yield return null;
            }
            screen.gameObject.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
