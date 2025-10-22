using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private PoissonDiscGrid grid = PoissonDiscGrid.Instance;

    public List<Node> FindPath(Vector2 startPos, Vector2 targetPos)
    {
        //Iniitialize start and target nodes
        Node startNode = grid.GetClosestPoint(startPos);
        Node targetNode = grid.GetClosestPoint(targetPos);

        targetNode.MakeTargetNode(startNode);
        startNode.MakeStartNode(targetNode);

        //Initialize open and checked sets
        List<Node> openSet = new List<Node>();
        HashSet<Node> checkedSet = new HashSet<Node>();
        openSet.Add(startNode);

        Node currentNode = openSet[0];
        List<Node> neighbors = grid.GetNeighbors(currentNode);
        foreach (Node neighbor in neighbors)
        {
            //Give neighbor references to currentNode and targetNode to calculate costs
            neighbor.GiveReferences(currentNode, targetNode);

            openSet.Add(neighbor);
        }

        //fCost = gCost(Distance from start) + hCost (Distance from target)
        while (openSet.Count > 0)
        {
            if (openSet.Count > 1)
            {
                for (int i = 0; i < openSet.Count; i++)
                {
                    if (openSet[i] == currentNode) continue;

                    //Looking for node with lowest fCost or hCost if fCosts are equal
                    Debug.Log("Comparing node with fCost: " + openSet[i].fCost + " to currentNode with fCost: " + currentNode.fCost);
                    if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                    {
                        Debug.Log("New currentNode found with fCost: " + openSet[i].fCost);
                        currentNode = openSet[i];

                        //End condition
                        if (currentNode == targetNode || (currentNode.worldPosition - targetNode.worldPosition).magnitude < 1.0f)
                        {
                            Debug.Log("Path found with gcost: " + currentNode.gCost);
                            return RetracePath(startNode, currentNode);
                        }

                        //Check each neighbor of currentNode
                        neighbors = grid.GetNeighbors(currentNode);
                        if (neighbors.Count == 0) continue;
                        foreach (Node checkableNeighbor in neighbors)
                        {
                            //Make sure neighbor was not checked
                            if (checkedSet.Contains(checkableNeighbor))
                            {
                                Debug.Log("Neighbor at " + checkableNeighbor.worldPosition + " already checked, skipping.");
                                continue;
                            }

                            //Give neighbor references to currentNode and targetNode to calculate costs
                            checkableNeighbor.GiveReferences(currentNode, targetNode);

                            Debug.Log("Neighbor at " + checkableNeighbor.worldPosition + " with gCost: " + checkableNeighbor.gCost + " and hCost: " + checkableNeighbor.hCost);
                            if (!openSet.Contains(checkableNeighbor) && !checkedSet.Contains(checkableNeighbor))
                            {
                                Debug.Log("Adding neighbor at " + checkableNeighbor.worldPosition + " to openSet.");
                                openSet.Add(checkableNeighbor);
                            }
                        }
                    }
                    else if (currentNode != startNode) currentNode.CleanUp();
                }
            }
            if (openSet.Contains(currentNode))
            {
                //Move currentNode from openSet to checkedSet
                openSet.Remove(currentNode);
                if (!checkedSet.Contains(currentNode))
                {
                    checkedSet.Add(currentNode);
                }
            }
        }
        Debug.Log("No path found with " + checkedSet.Count + " nodes checked.");
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
                break;
            }
            currentNode = currentNode.parent;
        }
        path.Reverse();
        return path;
    }
}
