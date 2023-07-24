using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BodyAttributes : MonoBehaviour
{
    Character character = new Character(); //reference to the Character class
    public GameObject[] parentSubjects = new GameObject[2]; //number of parents in the population (parents)
    public GameObject[] newParentSubjects = new GameObject[2]; //number of new parents in the population (parents)
    public GameObject[] childrenSubjects = new GameObject[10]; //number of sons in the population (children)
    public GameObject[] subjectBodyParts; // Array of body parts (head, torso, arms, legs)
    public Sprite[] subjectFigureParts; // Array of available primitives (triangle, square, hexagon, circle)
    public Color[] subjectColorPart; // Array of available colors (red, green, blue, yellow)
    public GameObject PerfectSubject; // The target character with the desired configuration (the perfect subject)

    [Range(0, 100)] public int mutationRange; // The range of mutation (the probability of mutation)
    

    private void Start()
    {
        //Start The Game by Generating Random Parents of the population 
        for (int i = 0; i < parentSubjects.Length; i++)
        {
            for (int j = 0; j < subjectBodyParts.Length; j++)
            {
                parentSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().sprite = subjectFigureParts[Random.Range(0,subjectFigureParts.Length)]; //Add random primitive
                parentSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().color = subjectColorPart[Random.Range(0,subjectColorPart.Length)]; //Add random color
                newParentSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().sprite = null; //initialize the new parent
                newParentSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().color = Color.white; //initialize the new parent
            }
        }
    }

    public void GenerateChildren()
    {
        for (int i = 0; i < parentSubjects.Length/2; i++) 
        {
            for (int j = 0; j < childrenSubjects.Length; j++)
            {
                if (j < childrenSubjects.Length/2) //First Half of Children
                {
                    for (int k = 0; k < subjectBodyParts.Length/2; k++) //Father Gens
                    {
                        //TODO: Add Mutation
                        if (Random.Range(0, 100) < mutationRange) //Add probability of Mutation
                        {
                            AddMutation(j,k);
                        }
                        else
                        {
                            childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite = parentSubjects[i].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite;
                            childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().color = parentSubjects[i].transform.GetChild(k).GetComponent<SpriteRenderer>().color;
                        }
                    }
                    for (int k = subjectBodyParts.Length/2; k < subjectBodyParts.Length; k++) //Mother Gens
                    {
                        //TODO : Add Mutation
                        if (Random.Range(0, 100) < mutationRange) //Add probability of Mutation
                        {
                            AddMutation(j,k);
                        }
                        else
                        {
                            childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite = parentSubjects[i + 1].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite;
                            childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().color = parentSubjects[i + 1].transform.GetChild(k).GetComponent<SpriteRenderer>().color;
                        }
                    }
                }
                else //Second Half of Children
                {
                    for (int k = 0; k < subjectBodyParts.Length/2; k++) //Mother Gens
                    {
                        //TODO: Add Mutation
                        if (Random.Range(0, 100) < mutationRange) //Add probability of Mutation
                        {
                            AddMutation(j,k);
                        }
                        else
                        {
                            childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite = parentSubjects[i+1].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite;
                            childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().color = parentSubjects[i+1].transform.GetChild(k).GetComponent<SpriteRenderer>().color;
                        }
                    }
                    for (int k = subjectBodyParts.Length/2; k < subjectBodyParts.Length; k++) //Father Gens
                    {
                        //TODO: Add Mutation
                        if (Random.Range(0, 100) < mutationRange) //Add probability of Mutation
                        {
                            AddMutation(j,k);
                        }
                        else
                        {
                            childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite = parentSubjects[i].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite;
                            childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().color = parentSubjects[i].transform.GetChild(k).GetComponent<SpriteRenderer>().color;
                        }
                    }
                }
            }
        }
    }
    
    //instantiate the prefab of perfect specimen
    public void InstantiatePerfectSubject()
    {
        if (PerfectSubject != null)
        {
            Destroy(PerfectSubject);
        }
        PerfectSubject = Instantiate(PerfectSubject, new Vector3(-7.21f, 3.46f, 0), Quaternion.identity);
    }


    public void EvaluateChildren()
    {
        int highestScore = 0;
        for (int k = 0; k < parentSubjects.Length; k++) //Loop for each parent to generate both mother and father 
        {
            for (int i = 0; i < childrenSubjects.Length; i++) //check each child which is the best
            {
                for (int j = 0; j < subjectBodyParts.Length; j++) //check each body part of the child
                {
                    if (childrenSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().sprite == PerfectSubject.transform.GetChild(j).GetComponent<SpriteRenderer>().sprite)
                    {
                        character.score += 1; //can add more score if the child has the same sprite as the perfect subject
                    }
                    if (childrenSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().color == PerfectSubject.transform.GetChild(j).GetComponent<SpriteRenderer>().color)
                    {
                        character.score += 1; //can add more score if the child has the same color as the perfect subject
                    }
                }
                childrenSubjects[i].GetComponent<Character>().score = character.score; //set the score of the child
                //Debug.Log("Children Subject ["+childrenSubjects[i]+"] Score: "+character.score);
                if (highestScore <= character.score) //check which child has the highest score
                {
                    highestScore = character.score; //set the highest score
                    newParentSubjects[k] = childrenSubjects[i]; //set the probably new parent
                }
                character.score = 0; //reset the score for the next child
            }
            
            //call function for redrawing the parents
            SelectParents(k); //k is the parent number
            
            for (int i = 0; i < childrenSubjects.Length; i++) //loop each children to make null the winner children
            {
                if (childrenSubjects[i] == newParentSubjects[k]) //check which child is the winner
                {
                    Debug.Log("New Parent Subject ["+newParentSubjects[k]+"] from Child: "+childrenSubjects[i]);
                    for (int j = 0; j < subjectBodyParts.Length; j++) //check each body part of the child
                    {
                        //Set the winner children color and sprite to Default Value
                        childrenSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().sprite = null;
                        childrenSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().color = Color.white;
                    }
                }
            }
            Debug.Log(parentSubjects[k]+" is replaced by "+newParentSubjects[k]);
        }
    }
    
    private void SelectParents(int parentIndex)
    {
        for (int i = 0; i < subjectBodyParts.Length; i++)
        {
            parentSubjects[parentIndex].transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = newParentSubjects[parentIndex].transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
            parentSubjects[parentIndex].transform.GetChild(i).GetComponent<SpriteRenderer>().color = newParentSubjects[parentIndex].transform.GetChild(i).GetComponent<SpriteRenderer>().color;
        }
    }
    
    
    public void ResetChildren()
    {
        for (int i = 0; i < childrenSubjects.Length; i++)
        {
            for (int j = 0; j < subjectBodyParts.Length; j++)
            {
                childrenSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().sprite = null;
                childrenSubjects[i].transform.GetChild(j).GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
    
    private void AddMutation(int j, int k) //j is the child number, k is the body part number
    {
        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().sprite = subjectFigureParts[Random.Range(0,subjectFigureParts.Length)]; //Add random primitive
        childrenSubjects[j].transform.GetChild(k).GetComponent<SpriteRenderer>().color = subjectColorPart[Random.Range(0,subjectColorPart.Length)]; //Add random color
    }


}
