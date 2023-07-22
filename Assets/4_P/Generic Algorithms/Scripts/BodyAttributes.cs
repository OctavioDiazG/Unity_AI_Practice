using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BodyAttributes : MonoBehaviour
{
    Character character = new Character(); //reference to the Character class
    public GameObject[] parentSubjects = new GameObject[2]; //number of parents in the population (parents)
    public GameObject[] childrenSubjects = new GameObject[10]; //number of sons in the population (children)
    public GameObject[] subjectBodyParts; // Array of body parts (head, torso, arms, legs)
    public Sprite[] subjectFigureParts; // Array of available primitives (triangle, square, hexagon, circle)
    public Color[] subjectColorPart; // Array of available colors (red, green, blue, yellow)
    public GameObject PerfectSubject; // The target character with the desired configuration (the perfect subject)
    

    private void Start()
    {
        //Start The Game by Generating Random Parents of the population 
        for (int i = 0; i < parentSubjects.Length; i++)
        {
            for (int j = 0; j < subjectBodyParts.Length; j++)
            {
                parentSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().sprite = subjectFigureParts[Random.Range(0,subjectFigureParts.Length)];
                parentSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().color = subjectColorPart[Random.Range(0,subjectColorPart.Length)];
            }
        }
    }

    public void GenerateChildren()
    {
        for (int i = 0; i < parentSubjects.Length/2; i++)
        {
            for (int j = 0; j < childrenSubjects.Length; j++)
            {
                if (j < childrenSubjects.Length/2)
                {
                    for (int k = 0; k < subjectBodyParts.Length/2; k++) //Father Gens
                    {
                        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite = parentSubjects[i].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite;
                        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().color = parentSubjects[i].transform.GetChild(k).GetComponent<SpriteRenderer>().color;
                    }
                    for (int k = subjectBodyParts.Length/2; k < subjectBodyParts.Length; k++) //Mother Gens
                    {
                        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite = parentSubjects[i+1].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite;
                        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().color = parentSubjects[i+1].transform.GetChild(k).GetComponent<SpriteRenderer>().color;
                    }
                }
                else
                {
                    for (int k = 0; k < subjectBodyParts.Length/2; k++) //Mother Gens
                    {
                        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite = parentSubjects[i+1].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite;
                        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().color = parentSubjects[i+1].transform.GetChild(k).GetComponent<SpriteRenderer>().color;
                    }
                    for (int k = subjectBodyParts.Length/2; k < subjectBodyParts.Length; k++) //Father Gens
                    {
                        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite = parentSubjects[i].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite;
                        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().color = parentSubjects[i].transform.GetChild(k).GetComponent<SpriteRenderer>().color;
                    }
                }
            }
        }

        for (int i = 0; i < parentSubjects.Length/2; i++)
        {
            
        }
    }


}
