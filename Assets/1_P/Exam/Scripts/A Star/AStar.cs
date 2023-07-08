using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public Nodes startPoint;
    public Nodes endPoint;

    public Nodes currentNode;
    
    public Material green;


    public List<Nodes> closedList;
    public List<Nodes> openedList;

    private bool found;

    public void Method()
    {
        openedList.Add(startPoint);
        currentNode = startPoint;

        StartCoroutine(MethodCoroutine());

    }

    IEnumerator MethodCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);

            currentNode = openedList[0];

            foreach (Nodes node in openedList)
            {
                if (node.fCost < currentNode.fCost)
                {
                    currentNode = node;
                }
            }

            openedList.Remove(currentNode);
            closedList.Add(currentNode);

            if(currentNode == endPoint)
            {
                found = true;
                Trail();
                StopAllCoroutines();
            }

            foreach(Nodes neighbor in currentNode.neighbors)
            {
                if (neighbor.cost == 0 || closedList.Contains(neighbor))
                    continue;

                if(currentNode.distance + 1 < neighbor.distance  || !openedList.Contains(neighbor))
                {
                    GiveValuesToNode(neighbor);
                    neighbor.parent = currentNode;

                    if (!openedList.Contains(neighbor))
                    {
                        openedList.Add(neighbor);
                    }
                }


            }
        }
    }

    void GiveValuesToNode(Nodes _node)
    {
        _node.distance= currentNode.distance+1;
        _node.heuristic = Mathf.Abs(_node.position.x - endPoint.position.x) + Mathf.Abs(_node.position.y - endPoint.position.y);
        _node.fCost = _node.distance + _node.heuristic + _node.cost;
    }

    void Trail()
    {
        do
        {
            currentNode.gameObject.GetComponent<MeshRenderer>().material = green;
            currentNode = currentNode.parent;
        } while (currentNode != startPoint);

        currentNode.gameObject.GetComponent<MeshRenderer>().material = green;
    }
}
