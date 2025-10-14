using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private PoissonDiscGrid grid = PoissonDiscGrid.Instance;

    public List<Node> FindPath(Vector2 startPos, Vector2 targetPos)
    {
        //Iniitialize start and target nodes
        Node startNode = grid.GetNodeFromWorldPoint(startPos);
        Node targetNode = grid.GetNodeFromWorldPoint(targetPos);

        startNode.gCost = 0;
        startNode.hCost = (startNode.worldPosition - targetNode.worldPosition).sqrMagnitude;

        //Initialize open and checked sets
        List<Node> openSet = new List<Node>();
        HashSet<Node> checkedSet = new HashSet<Node>();
        openSet.Add(startNode);

        //fCost = gCost(Distance from start) + hCost (Distance from target)
        while (openSet.Count > 0)
        {
            Debug.Log("Open Set Count: " + openSet.Count);
            Node currentNode = openSet[0];
            if (openSet.Count > 1)
            {
                for (int i = 1; i < openSet.Count; i++)
                {
                    //Looking for node with lowest fCost or hCost if fCosts are equal
                    if (openSet[i].fCost < currentNode.fCost ||
                        (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                    {
                        currentNode = openSet[i];
                    }
                }
            }

            //Move currentNode from openSet to checkedSet
            openSet.Remove(currentNode);
            checkedSet.Add(currentNode);

            //End condition
            if (currentNode == targetNode)
            {
                Debug.Log("Path found!");
                return RetracePath(startNode, targetNode);
            }

            //Check each neighbor of currentNode
            List<Node> neighbors = grid.GetNeighbors(currentNode);
            Debug.Log("Current Node: " + currentNode.worldPosition + " has " + neighbors.Count + " neighbors.");
            foreach (Node neighbor in neighbors)
            {
                Debug.Log("Checking neighbor at: " + neighbor.worldPosition);
                //Make sure neighbor was not checked
                if (checkedSet.Contains(neighbor))
                {
                    continue;
                }

                //Calculate new gCost for neighbor
                float newMovementCostToNeighbor = currentNode.gCost + (currentNode.worldPosition - neighbor.worldPosition).sqrMagnitude;

                //If new gCost is lower or neighbor is not in openSet, update costs and parent
                if (newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.hCost = (neighbor.worldPosition - targetNode.worldPosition).sqrMagnitude;

                    if (!openSet.Contains(neighbor))
                    {
                        Debug.Log("Adding neighbor at: " + neighbor.worldPosition + " to open set.");
                        openSet.Add(neighbor);
                    }
                }
            }
        }
        return null; // No path found
    }
    
    private List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            if (currentNode.parent == null)
            {
                Debug.LogError("Current node has no parent, cannot retrace path.");
                break;
            }
            currentNode = currentNode.parent;
        }
        path.Reverse();
        Debug.Log("Path retraced: " + string.Join(" -> ", path.Select(n => n.worldPosition)));
        return path;
    }
}
