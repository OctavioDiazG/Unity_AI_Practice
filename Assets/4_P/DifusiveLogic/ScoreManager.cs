using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text damageText;
    public Text timeText;
    public Text healthText;
    public Text collectiblesText;
    public Text rankText;

    public int damage;
    public float time;
    public int health;
    public int collectibles;

    void Start()
    {
        // Actualiza los valores de daño, tiempo, salud y coleccionables según la lógica de tu juego
        // ...

        // Calcula el rango para cada puntaje individualmente
        string damageRank = CalculateRank(damage);
        string timeRank = CalculateRank(time);
        string healthRank = CalculateRank(health);
        string collectiblesRank = CalculateRank(collectibles);

        // Actualiza el texto en la UI con las letras en lugar de los números
        damageText.text = "Daño: " + damageRank;
        timeText.text = "Tiempo: " + timeRank;
        healthText.text = "Salud: " + healthRank;
        collectiblesText.text = "Coleccionables: " + collectiblesRank;

        // Calcula el rango general basado en los valores de daño, tiempo, salud y coleccionables
        string rank = CalculateOverallRank(damage, time, health, collectibles);
        rankText.text = "Rango: " + rank;
    }

    string CalculateRank(float value)
    {
        // Calcula el rango para un puntaje individual
        // Esta es solo una implementación de ejemplo, puedes ajustarla según tus necesidades
        string rank = "Error";
        if (value == time)
        {
            if (value >= 10) rank = "D";
            else if (value >= 8) rank = "C";
            else if (value >= 6) rank = "B";
            else if (value >= 4) rank = "A";
            else if (value >= 0.1) rank = "S";
            return rank;
        }
        //if collectables
        if (value == collectibles)
        {
            if (value >= 0) rank = "D";
            else if (value >= 2) rank = "C";
            else if (value >= 5) rank = "B";
            else if (value >= 8) rank = "A";
            else if (value >= 10) rank = "S";
            return rank;
        }
        if (value == damage)
        {
            if (value >= 400) rank = "S";
            else if (value >= 300) rank = "A";
            else if (value >= 200) rank = "B";
            else if (value >= 150) rank = "C";
            else if (value >= 0) rank = "D";
            return rank;
        }
        if (value == health)
        {
            if (value >= 90) rank = "S";
            else if (value >= 80) rank = "A";
            else if (value >= 70) rank = "B";
            else if (value >= 60) rank = "C";
            else if (value >= 1) rank = "D";
            return rank;
        }
        
        return rank;
    }

    string CalculateOverallRank(int damage, float time, int health, int collectibles)
    {
        // Calcula el rango general basado en los valores de daño, tiempo, salud y coleccionables
        // Esta es solo una implementación de ejemplo, puedes ajustarla según tus necesidades
        int score = (int)(damage * 0.2f - time * 0.3f + health * 0.2f + collectibles * 0.25f);
        Debug.Log (score);
        string rank = "D";
        if (score >= 90) rank = "S";
        else if (score >= 80) rank = "A";
        else if (score >= 70) rank = "B";
        else if (score >= 60) rank = "C";
        return rank;
    }
}



/*using UnityEngine;
using AForge.Fuzzy;

public class FuzzyRanking : MonoBehaviour
{
    public float playerHealth;
    public float timeElapsed;
    public float playerScore;

    void CheckRank()
    {
        // Inicializa el sistema de lógica difusa
        FuzzySet fsLowHealth = new FuzzySet("LowHealth", new TrapezoidalFunction(25, 50, TrapezoidalFunction.EdgeType.Right));
        FuzzySet fsMediumHealth = new FuzzySet("MediumHealth", new TrapezoidalFunction(25, 50, 75, 100));
        FuzzySet fsHighHealth = new FuzzySet("HighHealth", new TrapezoidalFunction(75, 100, TrapezoidalFunction.EdgeType.Left));
        LinguisticVariable lvHealth = new LinguisticVariable("Health", 0, 100);
        lvHealth.AddLabel(fsLowHealth);
        lvHealth.AddLabel(fsMediumHealth);
        lvHealth.AddLabel(fsHighHealth);

        FuzzySet fsLowTime = new FuzzySet("LowTime", new TrapezoidalFunction(25, 50, TrapezoidalFunction.EdgeType.Right));
        FuzzySet fsMediumTime = new FuzzySet("MediumTime", new TrapezoidalFunction(25, 50, 75, 100));
        FuzzySet fsHighTime = new FuzzySet("HighTime", new TrapezoidalFunction(75, 100, TrapezoidalFunction.EdgeType.Left));
        LinguisticVariable lvTime = new LinguisticVariable("Time", 0, 100);
        lvTime.AddLabel(fsLowTime);
        lvTime.AddLabel(fsMediumTime);
        lvTime.AddLabel(fsHighTime);

        FuzzySet fsLowScore = new FuzzySet("LowScore", new TrapezoidalFunction(25, 50, TrapezoidalFunction.EdgeType.Right));
        FuzzySet fsMediumScore = new FuzzySet("MediumScore", new TrapezoidalFunction(25, 50, 75, 100));
        FuzzySet fsHighScore = new FuzzySet("HighScore", new TrapezoidalFunction(75, 100, TrapezoidalFunction.EdgeType.Left));
        LinguisticVariable lvScore = new LinguisticVariable("Score", 0, 100);
        lvScore.AddLabel(fsLowScore);
        lvScore.AddLabel(fsMediumScore);
        lvScore.AddLabel(fsHighScore);

        FuzzySet fsRankF = new FuzzySet("RankF", new TrapezoidalFunction(10, 20, TrapezoidalFunction.EdgeType.Right));
        FuzzySet fsRankD = new FuzzySet("RankD", new TrapezoidalFunction(10, 20, 30, 40));
        FuzzySet fsRankC = new FuzzySet("RankC", new TrapezoidalFunction(30, 40, 50, 60));
        FuzzySet fsRankB = new FuzzySet("RankB", new TrapezoidalFunction(50, 60, 70, 80));
        FuzzySet fsRankA = new FuzzySet("RankA", new TrapezoidalFunction(70, 80, 90, 100));
        FuzzySet fsRankS = new FuzzySet("RankS", new TrapezoidalFunction(90, 100, TrapezoidalFunction.EdgeType.Left));
        LinguisticVariable lvRank = new LinguisticVariable("Rank", 0, 100);
        lvRank.AddLabel(fsRankF);
        lvRank.AddLabel(fsRankD);
        lvRank.AddLabel(fsRankC);
        lvRank.AddLabel(fsRankB);
        lvRank.AddLabel(fsRankA);
        lvRank.AddLabel(fsRankS);

        Database database = new Database();
        database.AddVariable(lvHealth);
        database.AddVariable(lvTime);
        database.AddVariable(lvScore);
        database.AddVariable(lvRank);

        InferenceSystem IS = new InferenceSystem(database, new CentroidDefuzzifier(1000));

        // Define las reglas difusas
        IS.NewRule("Rule 1", "IF Health IS HighHealth AND Time IS LowTime THEN Rank IS RankS");
        IS.NewRule("Rule 2", "IF Health IS HighHealth AND Time IS MediumTime THEN Rank IS RankA");
        IS.NewRule("Rule 3", "IF Health IS HighHealth AND Time IS HighTime THEN Rank IS RankB");
        IS.NewRule("Rule 4", "IF Health IS MediumHealth AND Time IS LowTime THEN Rank IS RankA");
        IS.NewRule("Rule 5", "IF Health IS MediumHealth AND Time IS MediumTime THEN Rank IS RankB");
        IS.NewRule("Rule 6", "IF Health IS MediumHealth AND Time IS HighTime THEN Rank IS RankC");
        IS.NewRule("Rule 7", "IF Health IS LowHealth AND Time IS LowTime THEN Rank IS RankB");
        IS.NewRule("Rule 8", "IF Health IS LowHealth AND Time IS MediumTime THEN Rank IS RankC");
        IS.NewRule("Rule 9", "IF Health IS LowHealth AND Time IS HighTime THEN Rank IS RankD");

        // Establece los valores de las variables de entrada
        IS.SetInput("Health", playerHealth);
        IS.SetInput("Time", timeElapsed);
        IS.SetInput("Score", playerScore);

        // Calcula el resultado difuso
        float result = (float)IS.Evaluate("Rank");

        // Muestra el resultado
        Debug.Log("Rango obtenido: " + result);
    }
}

*/