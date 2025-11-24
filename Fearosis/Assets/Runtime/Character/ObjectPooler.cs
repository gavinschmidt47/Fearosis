using UnityEngine;
using System.Collections.Generic;
using System;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }
    public int poolSize = 50;
    public float infectedPoolWeight = 10f;

    private Queue<GameObject> dayPool = new Queue<GameObject>();
    private Queue<GameObject> nightPool = new Queue<GameObject>();
    private Queue<GameObject> bobPool = new Queue<GameObject>();
    private Queue<GameObject> activePool = new Queue<GameObject>();

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
            foreach (GameObject obj in dayPool)
            {
                Destroy(obj);
            }
            dayPool.Clear();
        }
        if (nightPool.Count > 0)
        {
            foreach (GameObject obj in nightPool)
            {
                Destroy(obj);
            }
            nightPool.Clear();
        }
        if (bobPool.Count > 0)
        {
            foreach (GameObject obj in bobPool)
            {
                Destroy(obj);
            }
            bobPool.Clear();
        }
        if (activePool.Count > 0)
        {
            foreach (GameObject obj in activePool)
            {
                Destroy(obj);
            }
            activePool.Clear();
        }
        float dayPercent = 1f - ((float)fullGameStatsScript.infected / (float)fullGameStatsScript.population);
        float nightPercent = (float)fullGameStatsScript.infected / (float)fullGameStatsScript.population;

        float nightWeight = Mathf.Lerp(1f, infectedPoolWeight, Mathf.Abs(dayPercent - nightPercent));

        int nightCount = Mathf.RoundToInt(poolSize * nightPercent * nightWeight);
        int dayCount = poolSize - nightCount;
        Debug.Log($"Pool Sizes - Day: {dayCount}, Night: {nightCount}");
        
        for (int i = 0; i < dayCount; i++)
        {
            tempObj = Instantiate(dayCharacter, Vector3.zero, Quaternion.identity);
            tempObj.transform.SetParent(transform);
            dayPool.Enqueue(tempObj);
            tempObj.SetActive(false);
        }

        for (int i = 0; i < nightCount; i++)
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
            int random = UnityEngine.Random.Range(0, 3);
            if (random == 0) //if day
            {
                return ActivateObjectFromPool(dayPool);
            }
            else if (random == 1) //if night
            {
                return ActivateObjectFromPool(nightPool);
            }
            else //if bob
            {
                return ActivateObjectFromPool(bobPool);
            }
        }
        else if (dayPool.Count > 0 && nightPool.Count > 0) //if only day pool and night pool has objects
        {
            int random = UnityEngine.Random.Range(0, 2);
            if (random == 0) //if day
            {
                return ActivateObjectFromPool(dayPool);
            }
            else //if night
            {
                return ActivateObjectFromPool(nightPool);
            }
        }
        else if (nightPool.Count > 0) //if only night pool has objects
        {
            return ActivateObjectFromPool(nightPool);
        }
        else if (dayPool.Count > 0) //if only day pool has objects
        {
            return ActivateObjectFromPool(dayPool);
        }
        else if (bobPool.Count > 0) //if only bob pool has objects
        {
            return ActivateObjectFromPool(bobPool);
        }
        return null; 
    }

    private GameObject ActivateObjectFromPool(Queue<GameObject> pool)
    {
        if (pool.Count == 0)
        {
            return null;
        }
        GameObject obj = pool.Dequeue();
        obj.SetActive(true);
        activePool.Enqueue(obj);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        if (activePool.Count > 0)
            activePool.Dequeue();
        if (obj.CompareTag("DayCharacter"))
        {
            dayPool.Enqueue(obj);
        }
        else if (obj.CompareTag("NightCharacter"))
        {
            nightPool.Enqueue(obj);
        }
        else if (obj.CompareTag("BobCharacter"))
        {
            bobPool.Enqueue(obj);
        }
    }
}