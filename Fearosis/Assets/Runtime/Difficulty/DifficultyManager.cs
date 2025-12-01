using UnityEngine;

public enum DifficultyLevel
{
    Normal,
    Hard,
    Impossible
}

public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
    private DifficultySettingsSO[] difficultyOptions;

    [SerializeField]
    private DifficultyLevel selectedDifficulty;

    private DifficultySettingsSO ActiveDifficulty => difficultyOptions[(int)selectedDifficulty];

    public void ApplyDifficultySettings(FullGameStats gameStats, Influence influence)
    {
        var settings = ActiveDifficulty;
        if (settings == null) return;

        gameStats.population = settings.population;
        gameStats.infected = settings.startingInfected;
        gameStats.hunters = settings.startingHunters;
        influence.influencePoints = settings.numberPointStart;
        // Apply other settings as needed

        Debug.Log($"Difficulty applied: {selectedDifficulty}, Population: {gameStats.population}, Infected: {gameStats.infected}");
    }

    private void Start()
    {
        var gameStats = FindAnyObjectByType<FullGameStats>();
        var influence = FindAnyObjectByType<Influence>();
        ApplyDifficultySettings(gameStats, influence);
    }
}
