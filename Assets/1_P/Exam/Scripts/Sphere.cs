using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public List<Transform> neighbors = new List<Transform>();

    private void Awake()
    {
        // Add all child objects as neighbors
        for (int i = 0; i < transform.childCount; i++)
        {
            neighbors.Add(transform.GetChild(i));
        }
    }
}
