/*
using UnityEngine;
using System.Collections.Generic;

public class GeneticAlgorithm : MonoBehaviour
{
    private CharacterEvaluator characterEvaluator;
    private CharacterGenerator characterGenerator;
    public float mutationRate = 0.1f; // Mutation rate as a percentage

    public List<Character> population; // The current population of characters

    private List<Character> newPopulation; // The new population of characters after reproduction and mutation
    
    public int populationSize = 10; // Number of characters in the population

    public Character targetCharacter; // The target character with the desired configuration


    private void Start()
    {
        GenerateInitialPopulation();
        ReproduceAndMutate();
    }
    
    private void GenerateInitialPopulation()
    {
        population = new List<Character>();

        for (int i = 0; i < populationSize; i++)
        {
            GameObject characterObj = new GameObject("Character");
            Character character = characterObj.AddComponent<Character>();

            // Create head
            GameObject headObj = CreateBodyPart("Head", GetRandomPrimitive(), GetRandomColor());
            headObj.transform.SetParent(characterObj.transform);
            character.head = headObj;

            // Create torso
            GameObject torsoObj = CreateBodyPart("Torso", GetRandomPrimitive(), GetRandomColor());
            torsoObj.transform.SetParent(characterObj.transform);
            character.torso = torsoObj;

            // Create right arm
            GameObject rightArmObj = CreateBodyPart("RightArm", GetRandomPrimitive(), GetRandomColor());
            rightArmObj.transform.SetParent(characterObj.transform);
            character.rightArm = rightArmObj;

            // Create left arm
            GameObject leftArmObj = CreateBodyPart("LeftArm", GetRandomPrimitive(), GetRandomColor());
            leftArmObj.transform.SetParent(characterObj.transform);
            character.leftArm = leftArmObj;

            // Create right leg
            GameObject rightLegObj = CreateBodyPart("RightLeg", GetRandomPrimitive(), GetRandomColor());
            rightLegObj.transform.SetParent(characterObj.transform);
            character.rightLeg = rightLegObj;

            // Create left leg
            GameObject leftLegObj = CreateBodyPart("LeftLeg", GetRandomPrimitive(), GetRandomColor());
            leftLegObj.transform.SetParent(characterObj.transform);
            character.leftLeg = leftLegObj;

            population.Add(character);
        }

        EvaluatePopulation();
    }
    
    private GameObject CreateBodyPart(string name, PrimitiveType shape, ColorType color)
    {
        GameObject bodyPart = new GameObject(name);
        SpriteRenderer spriteRenderer = bodyPart.AddComponent<SpriteRenderer>();

        // Assign shape sprite based on the primitive type
        switch (shape)
        {
            case PrimitiveType.Circle:
                // Set the circle sprite
                break;
            case PrimitiveType.Square:
                // Set the square sprite
                break;
            case PrimitiveType.Hexagon:
                // Set the hexagon sprite
                break;
            case PrimitiveType.Triangle:
                // Set the triangle sprite
                break;
            default:
                // Handle default case
                break;
        }

        // Assign color to the sprite renderer
        switch (color)
        {
            case ColorType.Red:
                spriteRenderer.color = Color.red;
                break;
            case ColorType.Green:
                spriteRenderer.color = Color.green;
                break;
            case ColorType.Blue:
                spriteRenderer.color = Color.blue;
                break;
            case ColorType.Yellow:
                spriteRenderer.color = Color.yellow;
                break;
            default:
                // Handle default case
                break;
        }

        return bodyPart;
    }
    
    private void EvaluatePopulation()
    {
        foreach (Character character in population)
        {
            int fitness = characterEvaluator.CalculateFitness(character);

            if (fitness == 12) // Termination condition: Character matches the target configuration
            {
                Debug.Log("Termination condition met. Found character with desired configuration.");
                //Debug.Log($"Character: {character.head}, {character.torso}, {character.rightArm}, {character.leftArm}, {character.rightLeg}, {character.leftLeg} | " +
                          //$"Colors: {character.headColor}, {character.torsoColor}, {character.rightArmColor}, {character.leftArmColor}, {character.rightLegColor}, {character.leftLegColor}");
                return;
            }
        }

        ReproduceAndMutate();
    }


    private void ReproduceAndMutate()
    {
        List<Character> newPopulation = new List<Character>();

        while (newPopulation.Count < populationSize)
        {
            Character parent1 = SelectParent();
            Character parent2 = SelectParent();

            Character offspring = Crossover(parent1, parent2);
            Mutate(offspring);

            newPopulation.Add(offspring);
        }

        population = newPopulation;

        EvaluatePopulation();
    }

    private Character SelectParent()
    {
        int index = Random.Range(0, population.Count);
        return population[index];
    }

    private Character Crossover(Character parent1, Character parent2)
    {
        Character offspring = new Character();

        // Perform crossover for primitives
        if (Random.value < 0.5f)
        {
            offspring.head = parent1.head;
            offspring.torso = parent1.torso;
        }
        else
        {
            offspring.head = parent2.head;
            offspring.torso = parent2.torso;
        }

        // Perform crossover for colors
        if (Random.value < 0.5f)
        {
            offspring.headColor = parent1.headColor;
            offspring.torsoColor = parent1.torsoColor;
        }
        else
        {
            offspring.headColor = parent2.headColor;
            offspring.torsoColor = parent2.torsoColor;
        }

        return offspring;
    }

    private void Mutate(Character character)
    {
        if (Random.value < mutationRate)
        {
            character.head = GetRandomPrimitive();
        }

        if (Random.value < mutationRate)
        {
            character.torso = GetRandomPrimitive();
        }

        // Mutate other character properties as needed
        // ...

        if (Random.value < mutationRate)
        {
            character.headColor = GetRandomColor();
        }

        if (Random.value < mutationRate)
        {
            character.torsoColor = GetRandomColor();
        }

        // Mutate other character properties as needed
        // ...
    }

    private PrimitiveType GetRandomPrimitive()
    {
        return characterGenerator.availablePrimitives[Random.Range(0, characterGenerator.availablePrimitives.Length)];

    }

    private ColorType GetRandomColor()
    {
        return characterGenerator.availableColors[Random.Range(0, characterGenerator.availableColors.Length)];
    }

    private void PrintPopulation()
    {
        foreach (Character character in population)
        {
            Debug.Log($"Character: {character.head}, {character.torso} | Colors: {character.headColor}, {character.torsoColor}");
        }
    }
}
*/