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
            person.SetActive(true);
                Node startNode = grid.GetRandomValidNode();
                person.transform.position = startNode.worldPosition;
                StartCoroutine(person.GetComponent<Character>().ChooseRandomDestination(startNode, grid.GetRandomTargetNode()));
                Debug.Log("Spawned person at: " + person.transform.position);
                person.GetComponent<Character>().reachDestinationEvent += () =>
                {
                    objectPooler.ReturnObject(person);
                };
                StartCoroutine(DieAfterTime(person, 10f)); // Despawn after 10 seconds
            }
        
        //StartCoroutine(SpawnPeople());
    }

    private IEnumerator SpawnPeople()
    {
        while (true)
        {
            GameObject person = objectPooler.GetObject();
            if (person != null)
            {
                person.SetActive(true);
                Node startNode = grid.GetRandomValidNode();
                person.transform.position = startNode.worldPosition;
                StartCoroutine(person.GetComponent<Character>().ChooseRandomDestination(startNode, grid.GetRandomTargetNode()));
                Debug.Log("Spawned person at: " + person.transform.position);
                person.GetComponent<Character>().reachDestinationEvent += () =>
                {
                    objectPooler.ReturnObject(person);
                };
                StartCoroutine(DieAfterTime(person, 10f)); // Despawn after 10 seconds
            }
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }

    private IEnumerator DieAfterTime(GameObject person, float time)
    {
        yield return new WaitForSeconds(time);
        objectPooler.ReturnObject(person);
    }
}
