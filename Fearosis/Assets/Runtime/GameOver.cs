using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Infection infectionScript;

    public void CheckGameOver()
    {
        infectionScript = FindAnyObjectByType<Infection>();
        
        if (infectionScript.infected >= infectionScript.population)
        {
            //WIN
        }
        if (infectionScript.infected <= 0)
        {
            //LOSE
        }
    }
}
