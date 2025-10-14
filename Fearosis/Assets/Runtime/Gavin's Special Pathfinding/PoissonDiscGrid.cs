using System.Collections.Generic;
using UnityEngine;

public class PoissonDiscGrid : MonoBehaviour
{
    public static PoissonDiscGrid Instance { get; private set; }

    //Must be edited in code, not in the Unity Editor, as this is a static class
    private int pointCount = 200;
    private float checkRadius = 2.5f;
    private float cellSize = 0.1f;

    private Bounds mapBounds;
    public List<Node> validPoints;
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
        mapBounds = GameObject.FindGameObjectWithTag("Map").GetComponent<SpriteRenderer>().bounds;
        validPoints = GeneratePoints();
    }

    private List<Node> GeneratePoints()
    {
        //Poisson Disc Sampling algorithm
        List<Node> points = new List<Node>();
        int attempts = 0;
        while (points.Count < pointCount && attempts < pointCount * 10)
        {
            Vector2 randomPoint = new Vector2(
                Random.Range(mapBounds.min.x, mapBounds.max.x),
                Random.Range(mapBounds.min.y, mapBounds.max.y)
            );

            Debug.Log("Generated point: " + randomPoint);
            if (IsPointValid(new Node(randomPoint), points))
            {
                points.Add(new Node(randomPoint));
            }
            attempts++;
        }
        return points;
    }

    private bool IsPointValid(Node point, List<Node> points)
    {
        //Checks for other points within the checkRadius
        foreach (var existingPoint in points)
        {
            //Checks for other points
            if (Vector2.Distance(point.worldPosition, existingPoint.worldPosition) < cellSize)
            {
                return false;
            }
        }
        //Checks for buildings and obstacles
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(point.worldPosition, cellSize);
        if (hitColliders.Length > 0)
        {
            foreach (var collider in hitColliders)
            {
                if (collider.CompareTag("Obstacle"))
                {
                    return false;
                }
            }
        }
        return true;
    }

    //Gets the closest valid point to a given position
    public Node GetClosestPoint(Vector2 position)
    {
        Node closestNode = validPoints[0];
        float closestDistance = (position - closestNode.worldPosition).sqrMagnitude;
        foreach (var point in validPoints)
        {
            float distance = (position - point.worldPosition).sqrMagnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNode = point;
            }
        }
        return closestNode;
    }

    //Gets the node corresponding to a world position
    public Node GetNodeFromWorldPoint(Vector2 worldPosition)
    {
        return GetClosestPoint(worldPosition);
    }

    //Gets all neighbors within a certain radius
    public List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        Node left = GetClosestPoint(node.worldPosition + Vector2.left * checkRadius);
        Node right = GetClosestPoint(node.worldPosition + Vector2.right * checkRadius);
        Node up = GetClosestPoint(node.worldPosition + Vector2.up * checkRadius);
        Node down = GetClosestPoint(node.worldPosition + Vector2.down * checkRadius);
        if (left.worldPosition != node.worldPosition)
        {
            neighbors.Add(left);
        }
        if (right.worldPosition != node.worldPosition && !neighbors.Contains(right))
        {
            neighbors.Add(right);
        }
        if (up.worldPosition != node.worldPosition && !neighbors.Contains(up))
        {
            neighbors.Add(up);
        }
        if (down.worldPosition != node.worldPosition && !neighbors.Contains(down))
        {
            neighbors.Add(down);
        }
        return neighbors;
    }

    public Node GetRandomNode()
    {
        if (validPoints.Count == 0)
        {
            Debug.LogError("No valid points available.");
            return null;
        }
        int randomIndex = Random.Range(0, validPoints.Count);
        return validPoints[randomIndex];
    }
}
