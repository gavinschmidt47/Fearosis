using UnityEngine;

public class GameOver : MonoBehaviour
{
    private FullGameStats fullGameStatsScript;

    public void CheckGameOver()
    {
        fullGameStatsScript = FindAnyObjectByType<FullGameStats>();

        if (fullGameStatsScript.infected >= fullGameStatsScript.population)
        {
            //WIN
        }
        if (fullGameStatsScript.infected <= 0)
        {
            //LOSE
        }
    }
}
