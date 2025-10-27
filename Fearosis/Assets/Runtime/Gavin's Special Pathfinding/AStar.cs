using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private PoissonDiscGrid grid = PoissonDiscGrid.Instance;
    public int maxSearchIterations = 50;

    public List<Node> FindPath(Node startNode, Node targetNode)
    {

        if (!startNode.valid || !targetNode.valid || startNode == null || targetNode == null)
        {
            Debug.LogWarning("Start or target node is invalid. Start Node Valid: " + startNode.valid + ", Target Node Valid: " + targetNode.valid);
            return null;
        }

        targetNode.MakeTargetNode(startNode);
        startNode.MakeStartNode(targetNode);

        //Initialize open and checked sets
        List<Node> openSet = new List<Node>();
        HashSet<Node> checkedSet = new HashSet<Node>();
        openSet.Add(startNode);

        int iterations = 0;

        //fCost = gCost(Distance from start) + hCost (Distance from target)
        while (openSet.Count > 0 && iterations < maxSearchIterations)
        {
            iterations++;

            //Find node in openSet with lowest fCost
            Node currentNode = openSet.OrderBy(n => n.fCost).ThenBy(n => n.hCost).First();

            //Move currentNode from openSet to checkedSet
            openSet.Remove(currentNode);
            checkedSet.Add(currentNode);

            //End condition - reached target
            if (currentNode == targetNode)
            {
                Debug.Log("Path found with gcost: " + currentNode.gCost + " in " + iterations + " iterations");
                return RetracePath(startNode, currentNode);
            }

            //Check each neighbor of currentNode
            List<Node> neighbors = grid.GetNeighbors(currentNode);
            foreach (Node neighbor in neighbors)
            {
                if (!neighbor.valid || checkedSet.Contains(neighbor))
                {
                    continue; //Skip invalid or already processed nodes
                }

                //Calculate tentative gCost for this path to neighbor
                float tentativeGCost = currentNode.gCost + (currentNode.worldPosition - neighbor.worldPosition).magnitude;

                //If neighbor is not in openSet or we found a better path
                if (!openSet.Contains(neighbor) || tentativeGCost < neighbor.gCost)
                {
                    //Update neighbor with better path
                    neighbor.GiveReferences(currentNode, targetNode);
                    neighbor.gCost = tentativeGCost;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                        Debug.Log("Adding neighbor at " + neighbor.worldPosition + " to openSet with fCost: " + neighbor.fCost);
                    }
                }
            }
        }

        Debug.LogWarning($"No path found after {iterations} iterations. OpenSet count: {openSet.Count}, CheckedSet count: {checkedSet.Count}");
        Debug.LogWarning($"Start node at {startNode.worldPosition} ({startNode.gridX}, {startNode.gridY}), Target node at {targetNode.worldPosition} ({targetNode.gridX}, {targetNode.gridY})");
        
        return null; //No path found
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
                Debug.LogWarning("Parent is null during path retracing. Path may be incomplete.");
                break;
            }
            currentNode = currentNode.parent;
        }
        
        // Add the start node to complete the path
        path.Add(startNode);
        path.Reverse();
        
        Debug.Log($"Path retraced with {path.Count} nodes");
        return path;
    }
}
