/*
using UnityEngine;
using System.Collections.Generic;

public class CharacterGenerator : MonoBehaviour
{
    public int populationSize = 10; // Number of characters in the population

    public PrimitiveType[] availablePrimitives; // Array of available primitives
    public ColorType[] availableColors; // Array of available colors

    private List<Character> population; // List to store the generated characters

    private void Start()
    {
        GeneratePopulation();
    }

    private void GeneratePopulation()
    {
        population = new List<Character>();

        for (int i = 0; i < populationSize; i++)
        {
            Character character = new Character();

            // Randomly assign primitives
            character.head = GetRandomPrimitive();
            character.torso = GetRandomPrimitive();
            character.rightArm = GetRandomPrimitive();
            character.leftArm = GetRandomPrimitive();
            character.rightLeg = GetRandomPrimitive();
            character.leftLeg = GetRandomPrimitive();

            // Randomly assign colors
            character.headColor = GetRandomColor();
            character.torsoColor = GetRandomColor();
            character.rightArmColor = GetRandomColor();
            character.leftArmColor = GetRandomColor();
            character.rightLegColor = GetRandomColor();
            character.leftLegColor = GetRandomColor();

            population.Add(character);
        }

        // Print the generated population
        PrintPopulation();
    }

    private PrimitiveType GetRandomPrimitive()
    {
        return availablePrimitives[Random.Range(0, availablePrimitives.Length)];
    }

    private ColorType GetRandomColor()
    {
        return availableColors[Random.Range(0, availableColors.Length)];
    }

    private void PrintPopulation()
    {
        foreach (Character character in population)
        {
            Debug.Log($"Character: {character.head}, {character.torso}, {character.rightArm}, {character.leftArm}, {character.rightLeg}, {character.leftLeg} | " +
                      $"Colors: {character.headColor}, {character.torsoColor}, {character.rightArmColor}, {character.leftArmColor}, {character.rightLegColor}, {character.leftLegColor}");
        }
    }
}
*/

