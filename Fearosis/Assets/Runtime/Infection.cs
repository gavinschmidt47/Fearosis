using UnityEngine;

public class Infection : MonoBehaviour
{
    public int infected;
    public int population;

    public void AddInfected(int amount)
    {
        infected += amount;
        if (infected > population)
        {
            infected = population;
        }
    }
}
