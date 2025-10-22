using UnityEngine;

public class Node
{
    public Vector2 worldPosition;
    public int gridX;
    public int gridY;
    public bool valid;

    public float gCost = 0; // Cost from start node
    public float hCost = 0; // Heuristic cost to target node
    public Node parent = null; // For path retracing
    public Node target = null;

    public float fCost
    {
        get { return gCost + hCost; }
    }

    public Node(Vector2 worldPosition, int gridX, int gridY, bool valid)
    {
        this.worldPosition = worldPosition;
        this.gridX = gridX;
        this.gridY = gridY;
        this.valid = valid;
        parent = null;
        target = null;
    }

    public void GiveReferences(Node parent, Node target)
    {
        this.parent = parent;
        this.target = target;

        if (parent != null)
        {
            gCost = parent.gCost + (worldPosition - parent.worldPosition).magnitude;
        }
        else
        {
            gCost = 0;
        }

        if (target != null)
        {
            hCost = (worldPosition - target.worldPosition).magnitude;
        }
        else
        {
            hCost = 0;
        }
    }

    public void MakeValid()
    {
        valid = true;
    }

    public void MakeStartNode(Node target)
    {
        gCost = 0;
        hCost = (worldPosition - target.worldPosition).magnitude;
        parent = null;
    }
    public void MakeTargetNode(Node start)
    {
        gCost = (worldPosition - start.worldPosition).magnitude;
        hCost = 0;
    }
    public void CleanUp()
    {
        gCost = 0;
        hCost = 0;
        parent = null;
        target = null;
    }
}