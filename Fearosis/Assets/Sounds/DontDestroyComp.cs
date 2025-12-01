using UnityEngine;

public class DontDestroyComp : MonoBehaviour
{
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
