using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private PoissonDiscGrid grid = PoissonDiscGrid.Instance;
    public int maxSearchIterations = 50;

    public List<Node> FindPath(Node startNode, Node targetNode)
    {

        if (!startNode.valid || !targetNode.valid || startNode == null || targetNode == null) return null;

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
            if (currentNode == targetNode) return RetracePath(startNode, currentNode);

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

                    if (!openSet.Contains(neighbor)) openSet.Add(neighbor);
                }
            }
        }
        
        return null; //No path found
    }
    
    private List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            if (currentNode.parent == null) break;
            currentNode = currentNode.parent;
        }
        
        // Add the start node to complete the path
        path.Add(startNode);
        path.Reverse();
        
        return path;
    }
}
