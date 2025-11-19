using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }

    private Queue<GameObject> dayPool = new Queue<GameObject>();
    private Queue<GameObject> nightPool = new Queue<GameObject>();
    private Queue<GameObject> bobPool = new Queue<GameObject>();

    [SerializeField]
    private GameObject dayCharacter;
    [SerializeField]
    private GameObject nightCharacter;
    [SerializeField]
    private GameObject bobCharacter;

    private FullGameStats fullGameStatsScript;
    private PoissonDiscGrid grid;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        fullGameStatsScript = FindAnyObjectByType<FullGameStats>();
    }
    void Start()
    {
        grid = PoissonDiscGrid.Instance;

        MakePool();
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

        for (int i = 0; i < (fullGameStatsScript.population - fullGameStatsScript.infected) / 50; i++)
        {
            tempObj = Instantiate(dayCharacter, Vector3.zero, Quaternion.identity);
            tempObj.transform.SetParent(transform);
            dayPool.Enqueue(tempObj);
            tempObj.SetActive(false);
        }

        for (int i = 0; i < fullGameStatsScript.infected / 10; i++)
        {
            tempObj = Instantiate(nightCharacter, Vector3.zero, Quaternion.identity);
            tempObj.transform.SetParent(transform);
            nightPool.Enqueue(tempObj);
            tempObj.SetActive(false);
        }

        for (int i = 0; i < fullGameStatsScript.hunters; i++)
        {
            tempObj = Instantiate(bobCharacter, Vector3.zero, Quaternion.identity);
            tempObj.transform.SetParent(transform);
            bobPool.Enqueue(tempObj);
            tempObj.SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        if (dayPool.Count > 0 && nightPool.Count > 0 && bobPool.Count > 0)
        {
            Debug.Log("All pools have objects");
            int random = Random.Range(0, 3);
            if (random == 0) //if day
            {
                GameObject obj = dayPool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else if (random == 1) //if night
            {
                GameObject obj = nightPool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else //if bob
            {
                GameObject obj = bobPool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
        }
        else if (dayPool.Count > 0 && nightPool.Count > 0) //if only day pool and night pool has objects
        {
            int random = Random.Range(0, 2);
            if (random == 0) //if day
            {
                GameObject obj = dayPool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else //if night
            {
                GameObject obj = nightPool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
        }
        else if (nightPool.Count > 0) //if only night pool has objects
        {
            GameObject obj = nightPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else if (dayPool.Count > 0) //if only day pool has objects
        {
            GameObject obj = dayPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else if (bobPool.Count > 0) //if only bob pool has objects
        {
            GameObject obj = bobPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return null; 
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        if (obj.CompareTag("DayCharacter"))
        {
            dayPool.Enqueue(obj);
        }
        else if (obj.CompareTag("NightCharacter"))
        {
            nightPool.Enqueue(obj);
        }
    }
}