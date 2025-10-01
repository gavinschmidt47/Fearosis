using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    private Queue<GameObject> dayPool = new Queue<GameObject>();
    private Queue<GameObject> nightPool = new Queue<GameObject>();

    [SerializeField]
    private GameObject dayCharacter;
    [SerializeField]
    private GameObject nightCharacter;
    
    private FullGameStats fullGameStatsScript;

    void Start()
    {
        fullGameStatsScript = FindAnyObjectByType<FullGameStats>();
    }

    public void MakePool()
    {
        GameObject tempObj;
        if (dayPool.Count > 0)
        {
            dayPool.Clear();
        }
        if (nightPool.Count > 0)
        {
            nightPool.Clear();
        }

        for (int i = 0; i < (fullGameStatsScript.population - fullGameStatsScript.infected); i++)
        {
            tempObj = Instantiate(dayCharacter);
            tempObj.SetActive(false);
            dayPool.Enqueue(tempObj);
        }

        for (int i = 0; i < fullGameStatsScript.infected; i++)
        {
            tempObj = Instantiate(nightCharacter);
            tempObj.SetActive(false);
            nightPool.Enqueue(tempObj);
        }
    }

    public GameObject GetObject(bool dayOrNight) //true to grab day, false to grab night
    {
        if (dayPool.Count > 0 && (nightPool.Count != dayPool.Count))
        { 
            GameObject temp;
            if (dayOrNight) //if day
            {
                temp = dayPool.Dequeue();
                temp.SetActive(true);
                return temp;
            }
            else if (!dayOrNight) //if night
            {
                temp = nightPool.Dequeue();
                temp.SetActive(true);
                return temp;
            }
        }

        return null; 
    }

    public void ReturnObject(GameObject obj, bool dayOrNight)
    {
        if (dayOrNight) //if day
        {
            obj.SetActive(false);
            dayPool.Enqueue(obj);
        }
        else if (!dayOrNight) //if night
        {
            obj.SetActive(false);
            nightPool.Enqueue(obj);
        }
        
    }
}
