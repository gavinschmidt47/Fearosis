using UnityEngine;

public class DontDestroyComp : MonoBehaviour
{
    public bool isSingleton = true;
    void Awake()
    {
        if (FindObjectsByType<DontDestroyComp>(FindObjectsSortMode.None).Length > 1 && isSingleton)
        {
            DestroySelf();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);  
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
