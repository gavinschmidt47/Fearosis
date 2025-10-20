using System.Collections.Generic;
using UnityEngine;

public class PoissonDiscGrid : MonoBehaviour
{
    public static PoissonDiscGrid Instance { get; private set; }

    //Must be edited in code, not in the Unity Editor, as this is a static class
    private int pointCount = 700;
    private float checkRadius = 0.15f;
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

            if (IsPointValid(new Node(randomPoint), points))
            {
                points.Add(new Node(randomPoint));
                Debug.DrawLine(randomPoint, randomPoint + Vector2.up * 0.1f, Color.green, 100f);
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

    //Gets all neighbors within a certain radius
    public List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        Node upLeft = GetClosestPoint(node.worldPosition + new Vector2(-checkRadius, checkRadius));
        Node left = GetClosestPoint(node.worldPosition + Vector2.left * checkRadius);
        Node lowLeft = GetClosestPoint(node.worldPosition + new Vector2(-checkRadius, -checkRadius));
        Node lowRight = GetClosestPoint(node.worldPosition + new Vector2(checkRadius, -checkRadius));
        Node right = GetClosestPoint(node.worldPosition + Vector2.right * checkRadius);
        Node upRight = GetClosestPoint(node.worldPosition + new Vector2(checkRadius, checkRadius));
        Node up = GetClosestPoint(node.worldPosition + Vector2.up * checkRadius);
        Node down = GetClosestPoint(node.worldPosition + Vector2.down * checkRadius);
        if (upLeft.worldPosition != node.worldPosition)
        {
            neighbors.Add(upLeft);
        }
        else
        {
            upLeft = GetClosestPoint(node.worldPosition + new Vector2(-checkRadius * 1.5f, checkRadius * 1.5f));
            if (upLeft.worldPosition != node.worldPosition && !neighbors.Contains(upLeft))
            {
                neighbors.Add(upLeft);
            }
        }

        if (lowLeft.worldPosition != node.worldPosition && !neighbors.Contains(lowLeft))
        {
            neighbors.Add(lowLeft);
        }
        else
        {
            lowLeft = GetClosestPoint(node.worldPosition + new Vector2(-checkRadius * 1.5f, -checkRadius * 1.5f));
            if (lowLeft.worldPosition != node.worldPosition && !neighbors.Contains(lowLeft))
            {
                neighbors.Add(lowLeft);
            }
        }

        if (left.worldPosition != node.worldPosition)
        {
            neighbors.Add(left);
        }
        else
        {
            left = GetClosestPoint(node.worldPosition + Vector2.left * checkRadius * 1.5f);
            if (left.worldPosition != node.worldPosition && !neighbors.Contains(left))
            {
                neighbors.Add(left);
            }
        }

        if (lowRight.worldPosition != node.worldPosition && !neighbors.Contains(lowRight))
        {
            neighbors.Add(lowRight);
        }
        else
        {
            lowRight = GetClosestPoint(node.worldPosition + new Vector2(checkRadius * 1.5f, -checkRadius * 1.5f));
            if (lowRight.worldPosition != node.worldPosition && !neighbors.Contains(lowRight))
            {
                neighbors.Add(lowRight);
            }
        }

        if (right.worldPosition != node.worldPosition && !neighbors.Contains(right))
        {
            neighbors.Add(right);
        }
        else
        {
            right = GetClosestPoint(node.worldPosition + Vector2.right * checkRadius * 1.5f);
            if (right.worldPosition != node.worldPosition && !neighbors.Contains(right))
            {
                neighbors.Add(right);
            }
        }

        if (upRight.worldPosition != node.worldPosition && !neighbors.Contains(upRight))
        {
            neighbors.Add(upRight);
        }
        else
        {
            upRight = GetClosestPoint(node.worldPosition + new Vector2(checkRadius * 1.5f, checkRadius * 1.5f));
            if (upRight.worldPosition != node.worldPosition && !neighbors.Contains(upRight))
            {
                neighbors.Add(upRight);
            }
        }

        if (up.worldPosition != node.worldPosition && !neighbors.Contains(up))
        {
            neighbors.Add(up);
        }
        else
        {
            up = GetClosestPoint(node.worldPosition + Vector2.up * checkRadius * 1.5f);
            if (up.worldPosition != node.worldPosition && !neighbors.Contains(up))
            {
                neighbors.Add(up);
            }
        }

        if (down.worldPosition != node.worldPosition && !neighbors.Contains(down))
        {
            neighbors.Add(down);
        }
        else
        {
            down = GetClosestPoint(node.worldPosition + Vector2.down * checkRadius * 1.5f);
            if (down.worldPosition != node.worldPosition && !neighbors.Contains(down))
            {
                neighbors.Add(down);
            }
        }

        if (neighbors.Count == 0)
        {
            Debug.LogWarning("No neighbors found for node at " + node.worldPosition);
        }
        return neighbors;
    }

    public Node GetRandomNode()
    {
        if (validPoints.Count == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, validPoints.Count);
        return validPoints[randomIndex];
    }

    public List<Node> GetAllNodes()
    {
        return validPoints;
    }
}
