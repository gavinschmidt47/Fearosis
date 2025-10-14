using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public List<Vector2> destinations;
    public float speed = 2f;
    public float minWaitTime = 2f;
    public float maxWaitTime = 5f;
    public float arrivalThreshold = 0.1f;
    public float deathTime = 30f; // Time in seconds before the character dies

    private bool firstTimeAwake = true;
    private Rigidbody2D rb;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    [HideInInspector]
    public Animator animator;
    private AStar aStar;
    public event UnityAction reachDestinationEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aStar = GetComponent<AStar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void OnEnable()
    {
        if (firstTimeAwake)
        {
            firstTimeAwake = false;
            return;
        }
        else
        {
            StartCoroutine(ChooseRandomDestination());
        }
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    //Pick a random destination from the list and start moving towards it
    IEnumerator ChooseRandomDestination()
    {
        if (destinations.Count == 0) yield break;

        //Pick a random destination
        int randomIndex = Random.Range(0, destinations.Count);
        Vector2 randomDestination = destinations[randomIndex];

        //Find path using A* algorithm
        List<Node> path = aStar.FindPath(rb.position, randomDestination);
        if (path != null && path.Count > 0)
        {
            StartCoroutine(FollowPath(path));
            StartCoroutine(DieAfterTime(deathTime)); // Character will die after specified deathTime
        }
        yield return null;
    }

    //Moves the character towards the next point in the path
    public void MoveTo(Vector2 nextPoint)
    {
        Vector2 direction = (nextPoint - rb.position).normalized;
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    //Follows the calculated path to the destination
    private IEnumerator FollowPath(List<Node> path)
    {
        Debug.Log("Following path with " + path.Count + " nodes.");
        //Goes point by point in the path
        foreach (var node in path)
        {
            //Each fixed update, move towards the next node until close enough
            while ((rb.position - node.worldPosition).sqrMagnitude > arrivalThreshold * arrivalThreshold)
            {
                MoveTo(node.worldPosition);
                yield return new WaitForFixedUpdate();
            }
        }
        reachDestinationEvent?.Invoke();
        yield return null;
    }

    private IEnumerator DieAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Character has died.");
        gameObject.SetActive(false); // Deactivate the character
    }
}
