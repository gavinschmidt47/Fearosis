using System.Collections;
using UnityEngine;

public class RandomlyMovingPeople : MonoBehaviour
{
    [SerializeField]
    private float minSpawnInterval = 1f;
    [SerializeField]
    private float maxSpawnInterval = 3f;

    private ObjectPooler objectPooler;
    private PoissonDiscGrid grid;
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        grid = PoissonDiscGrid.Instance;
        GameObject person = objectPooler.GetObject();
        if (person != null)
        {
            Debug.Log("Spawning person");
            person.SetActive(true);
            person.transform.position = grid.GetRandomNode().worldPosition;
            person.GetComponent<Character>().reachDestinationEvent += () =>
            {
                objectPooler.ReturnObject(person);
            };
        }
        StartCoroutine(SpawnPeople());
    }

    private IEnumerator SpawnPeople()
    {
        while (true)
        {
            GameObject person = objectPooler.GetObject();
            if (person != null)
            {
                person.SetActive(true);
                person.transform.position = grid.GetRandomNode().worldPosition;
                person.GetComponent<Character>().reachDestinationEvent += () =>
                {
                    objectPooler.ReturnObject(person);
                };
            }
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }
}
