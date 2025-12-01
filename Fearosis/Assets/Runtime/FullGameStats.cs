using UnityEngine;

public class FullGameStats : MonoBehaviour
{
    public int infected;
    public int population;
    public int dead;
    public int hunters;
    public int round = 0;

    private GameOver gameOverScript;

    private void Awake()
    {
        gameOverScript = FindAnyObjectByType<GameOver>();
    }

    public void AddInfected(int amount)
    {
        infected += amount;
        if (infected > population)
        {
            infected = population;
            gameOverScript.CheckGameOver();
        }
    }
    public void KillInfected(int amount)
    {
        infected -= amount;
        population -= amount;
        dead += amount;
        if (infected < 0)
        {
            infected = 0;
            gameOverScript.CheckGameOver();
        }
    }
}
