using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes: MonoBehaviour
{
    private AStar aStar;
    public Vector2 position;
    public List<Nodes> neighbors;
    public Nodes parent;
    public int cost;
    public int distance;
    public float heuristic;
    public float fCost;

    private void Awake()
    {
        aStar = FindObjectOfType<AStar>();
    }
    private void Start()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4.1f))
        {
            neighbors.Add(hit.transform.gameObject.GetComponent<Nodes>());
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 4.1f))
        {
            neighbors.Add(hit.transform.gameObject.GetComponent<Nodes>());
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 4.1f))
        {
            neighbors.Add(hit.transform.gameObject.GetComponent<Nodes>());
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 4.1f))
        {
            neighbors.Add(hit.transform.gameObject.GetComponent<Nodes>());
        }
        
        aStar.Method();
    }
}
