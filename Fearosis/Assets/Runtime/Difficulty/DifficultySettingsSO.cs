using UnityEngine;

[CreateAssetMenu(fileName = "DifficultySettings", menuName = "Game/Difficulty Settings")]
public class DifficultySettingsSO : ScriptableObject
{
    [Header("Core Stats")]
    public int population;
    public int infectionRate;
    public int startingInfected;
    public int startingHunters;

    [Header("Point System")]
    public int numberPointStart;
    public int pointBuffStart;

    [Header("Thresholds")]
    public int painThreshold;
    public int hunterThreshold;

    [Header("Buffs")]
    public int fearBuff;
    public int notorietyBuff;
    public int prejudiceBuff;
    public int painBuff;
}