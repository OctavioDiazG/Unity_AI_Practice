using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfRanks : MonoBehaviour
{
public float playerScore;
public float playerHealth;
public float timeElapsed;
public float rankS_ScoreRequirement;
public float rankS_HealthRequirement;
public float rankS_TimeRequirement;
public float rankA_ScoreRequirement;
public float rankA_HealthRequirement;
public float rankA_TimeRequirement;
public float rankB_ScoreRequirement;
public float rankB_HealthRequirement;
public float rankB_TimeRequirement;
public float rankC_ScoreRequirement;
public float rankC_HealthRequirement;
public float rankC_TimeRequirement;
public float rankD_ScoreRequirement;
public float rankD_HealthRequirement;
public float rankD_TimeRequirement;

void CheckRank()
{
    if (playerScore >= rankS_ScoreRequirement && playerHealth >= rankS_HealthRequirement && timeElapsed <= rankS_TimeRequirement)
    {
        // El jugador ha cumplido los requisitos para obtener el Rango S
        // Actualiza la puntuación del jugador y muestra el rango obtenido
        playerScore += 1000; // Otorga puntos adicionales por obtener el Rango S
        Debug.Log("Rango S obtenido!");
    }
    else if (playerScore >= rankA_ScoreRequirement && playerHealth >= rankA_HealthRequirement && timeElapsed <= rankA_TimeRequirement)
    {
        // El jugador ha cumplido los requisitos para obtener el Rango A
        // Actualiza la puntuación del jugador y muestra el rango obtenido
        playerScore += 800; // Otorga puntos adicionales por obtener el Rango A
        Debug.Log("Rango A obtenido!");
    }
    else if (playerScore >= rankB_ScoreRequirement && playerHealth >= rankB_HealthRequirement && timeElapsed <= rankB_TimeRequirement)
    {
        // El jugador ha cumplido los requisitos para obtener el Rango B
        // Actualiza la puntuación del jugador y muestra el rango obtenido
        playerScore += 600; // Otorga puntos adicionales por obtener el Rango B
        Debug.Log("Rango B obtenido!");
    }
    else if (playerScore >= rankC_ScoreRequirement && playerHealth >= rankC_HealthRequirement && timeElapsed <= rankC_TimeRequirement)
    {
        // El jugador ha cumplido los requisitos para obtener el Rango C
        // Actualiza la puntuación del jugador y muestra el rango obtenido
        playerScore += 400; // Otorga puntos adicionales por obtener el Rango C
        Debug.Log("Rango C obtenido!");
    }
    else if (playerScore >= rankD_ScoreRequirement && playerHealth >= rankD_HealthRequirement && timeElapsed <= rankD_TimeRequirement)
    {
        // El jugador ha cumplido los requisitos para obtener el Rango D
        // Actualiza la puntuación del jugador y muestra el rango obtenido
        playerScore += 200; // Otorga puntos adicionales por obtener el Rango D
        Debug.Log("Rango D obtenido!");
    }
    else
    {
        // El jugador no ha cumplido los requisitos para obtener ningún rango superior a F
        Debug.Log("Rango F obtenido");
    }
}
}
