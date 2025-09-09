using UnityEngine;

public class Influence : MonoBehaviour
{
    public int influencePoints;

    public void AddInfluence(int amount)
    {
        influencePoints += amount;
    }
}
