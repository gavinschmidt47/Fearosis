using UnityEngine;

public class Node
{
    public Vector2 worldPosition;

    public float gCost = 0; // Cost from start node
    public float hCost = 0; // Heuristic cost to target node
    public Node parent = null; // For path retracing

    public float fCost
    {
        get { return gCost + hCost; }
    }

    public Node(Vector2 worldPosition)
    {
        this.worldPosition = worldPosition;

        if (parent != null)
        {
            gCost = parent.gCost + (parent.worldPosition - worldPosition).sqrMagnitude;
        }
    }
    public Node(Node parent, Vector2 worldPosition)
    {
        this.worldPosition = worldPosition;
        this.parent = parent;

        if (parent != null)
        {
            gCost = parent.gCost + (parent.worldPosition - worldPosition).sqrMagnitude;
        }
    }
}
