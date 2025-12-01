using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private FullGameStats fullGameStatsScript;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    public void CheckGameOver()
    {
        fullGameStatsScript = FindAnyObjectByType<FullGameStats>();

        if (fullGameStatsScript.infected >= fullGameStatsScript.population)
        {
            winScreen.SetActive(true);
            ResetGame();
            //WIN
        }
        if (fullGameStatsScript.infected <= 0)
        {
            loseScreen.SetActive(true);
            ResetGame();
            //LOSE
        }
    }

    public void ResetGame()
    {
        StartCoroutine(ResetGameCoroutine());
    }

    private System.Collections.IEnumerator ResetGameCoroutine()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("LevelSelect");
    }
}
