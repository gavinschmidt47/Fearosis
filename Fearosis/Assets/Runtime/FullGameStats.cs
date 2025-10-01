using UnityEngine;

public class FullGameStats : MonoBehaviour
{
    public int infected;
    public int population;
    public int hunters;
    public int round = 0;

    public void AddInfected(int amount)
    {
        infected += amount;
        if (infected > population)
        {
            infected = population;
        }
    }
}
