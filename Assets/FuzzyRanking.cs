using UnityEngine;
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

