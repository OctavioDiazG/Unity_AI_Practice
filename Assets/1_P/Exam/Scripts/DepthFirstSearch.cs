using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFirstSearch : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public LineRenderer lineRenderer;

    
    private List<Transform> visitedPoints = new List<Transform>();
    private List<Transform> path = new List<Transform>();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            visitedPoints.Clear();
            path.Clear();
            depthFirstSearch(startPoint);

            // Set the line renderer's position count to the number of points in the path
            lineRenderer.positionCount = path.Count;

            // Loop through the points in the path and set the line renderer's positions
            for (int i = 0; i < path.Count; i++)
            {
                lineRenderer.SetPosition(i, path[i].position);
            }
        }
    }

    private bool depthFirstSearch(Transform currentPoint)
    {
        // Mark the current point as visited
        visitedPoints.Add(currentPoint);

        // Add the current point to the path
        path.Add(currentPoint);

        // Check if the current point is the end point
        if (currentPoint == endPoint)
        {
            // End the search
            return true;
        }

        // Loop through all the neighbors of the current point
        foreach (Transform neighbor in currentPoint.GetComponent<Sphere>().neighbors)
        {
            // If the neighbor hasn't been visited yet, visit it
            if (!visitedPoints.Contains(neighbor))
            {
                if (depthFirstSearch(neighbor))
                {
                    // If the end point has been found, end the search
                    return true;
                }
            }
        }

        // If the end point wasn't found, remove the current point from the path and return false
        path.Remove(currentPoint);
        return false;
    }


    
    private List<Transform> GetNeighbors(Transform point)
    {
        List<Transform> neighbors = new List<Transform>();

        for (int i = 0; i < point.childCount; i++)
        {
            neighbors.Add(point.GetChild(i));
        }

        return neighbors;
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

}
