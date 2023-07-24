/*
using UnityEngine;
using System.Collections.Generic;

public class CharacterEvaluator : MonoBehaviour
{
    public Character targetCharacter; // The target character with the desired configuration

    public List<Character> population; // The generated population of characters

    private void Start()
    {
        EvaluatePopulation();
    }

    private void EvaluatePopulation()
    {
        foreach (Character character in population)
        {
            int fitness = CalculateFitness(character);
            Debug.Log($"Character Fitness: {fitness}");
        }
    }

    private int CalculateFitness(Character character)
    {
        int fitness = 0;

        if (GetPrimitiveType(character.head) == GetPrimitiveType(targetCharacter.head))
            fitness++;

        if (GetPrimitiveType(character.torso) == GetPrimitiveType(targetCharacter.torso))
            fitness++;

        if (GetPrimitiveType(character.rightArm) == GetPrimitiveType(targetCharacter.rightArm))
            fitness++;

        if (GetPrimitiveType(character.leftArm) == GetPrimitiveType(targetCharacter.leftArm))
            fitness++;

        if (GetPrimitiveType(character.rightLeg) == GetPrimitiveType(targetCharacter.rightLeg))
            fitness++;

        if (GetPrimitiveType(character.leftLeg) == GetPrimitiveType(targetCharacter.leftLeg))
            fitness++;

        if (GetColorType(character.head) == GetColorType(targetCharacter.head))
            fitness++;

        if (GetColorType(character.torso) == GetColorType(targetCharacter.torso))
            fitness++;

        if (GetColorType(character.rightArm) == GetColorType(targetCharacter.rightArm))
            fitness++;

        if (GetColorType(character.leftArm) == GetColorType(targetCharacter.leftArm))
            fitness++;

        if (GetColorType(character.rightLeg) == GetColorType(targetCharacter.rightLeg))
            fitness++;

        if (GetColorType(character.leftLeg) == GetColorType(targetCharacter.leftLeg))
            fitness++;

        return fitness;
    }
    
    private PrimitiveType GetPrimitiveType(GameObject bodyPart)
    {
        // Determine the PrimitiveType based on the shape of the body part
        // ...

        return PrimitiveType.Circle; // Replace with actual shape detection logic
    }
    
    private ColorType GetColorType(GameObject bodyPart)
    {
        SpriteRenderer spriteRenderer = bodyPart.GetComponent<SpriteRenderer>();

        // Determine the ColorType based on the color of the body part
        // ...

        return ColorType.Red; // Replace with actual color detection logic
    }
}
*/