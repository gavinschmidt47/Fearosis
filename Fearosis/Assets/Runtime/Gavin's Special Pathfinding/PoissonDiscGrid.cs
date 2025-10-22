using System.Collections.Generic;
using UnityEngine;

public class PoissonDiscGrid : MonoBehaviour
{
    public static PoissonDiscGrid Instance { get; private set; }

    //Must be edited in code, not in the Unity Editor, as this is a static class
    private int numRows = 20;
    private int numCols = 45;
    private float cellSize = 0.1f;

    private Bounds mapBounds;
    public Node[,] validPoints;
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

    private Node[,] GeneratePoints()
    {
        //Poisson Disc Sampling algorithm
        Node[,] points = new Node[numCols, numRows];

        //Generate grid of points
        for (int i = 0; i < numCols; i++)
        {
            for (int j = 0; j < numRows; j++)
            {
                Vector2 pointPosition = new Vector2(mapBounds.min.x + i, mapBounds.min.y + j);
                points[i, j] = new Node(pointPosition, i, j, false);

                //Check if the point is valid
                if (IsPointValid(points[i, j]))
                    points[i, j].MakeValid();
            }
        }
        return points;
    }

    private bool IsPointValid(Node point)
    {
        if (point.valid) return true;
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
        //Get distance to first point
        Node closestNode = validPoints[0, 0];
        float closestDistance = (position - closestNode.worldPosition).sqrMagnitude;

        //Iterate through all valid points to find the closest
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
        //Get starting grid position
        int startX = Mathf.Max(0, node.gridX - 1);
        int endX = Mathf.Min(numCols - 1, node.gridX + 1);
        int startY = Mathf.Max(0, node.gridY - 1);
        int endY = Mathf.Min(numRows - 1, node.gridY + 1);

        List<Node> neighbors = new List<Node>();

        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                //Skip the node itself
                if (x == node.gridX && y == node.gridY)
                    continue;

                Node neighborNode = validPoints[x, y];
                if (neighborNode.valid)
                {
                    neighbors.Add(neighborNode);
                }
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
        int randomX = UnityEngine.Random.Range(0, numCols);
        int randomY = UnityEngine.Random.Range(0,  numRows);
        return validPoints[randomX, randomY];
    }

    public Node[,] GetAllNodes()
    {
        return validPoints;
    }
}
