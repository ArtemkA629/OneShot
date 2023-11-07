using System;
using UnityEngine;

public class GlobalDataHolder : MonoBehaviour
{
    [SerializeField] private GameObject _weaponModelAtStart;

    public static LevelDifficulty LevelDifficulty { get; private set; }
    public static GameObject WeaponModel { get; private set; }
    public static int CoinsToAdd { get; private set; }

    public static void ResetCoinsAmount()
    {
        CoinsToAdd = 0;
    }

    private void OnEnable()
    {
        LevelButton.LevelChosen += OnLevelChosen;
        WeaponCard.Unchanged += OnUnchanged;
        Enemy.CoinsAmountChanging += OnCoinsAmountChanging;

        WeaponModel = _weaponModelAtStart;

        DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        LevelButton.LevelChosen -= OnLevelChosen;
        WeaponCard.Unchanged -= OnUnchanged;
        Enemy.CoinsAmountChanging -= OnCoinsAmountChanging;
    }

    private static void OnLevelChosen(LevelDifficulty levelDifficulty)
    {
        LevelDifficulty = levelDifficulty;
    }

    private static void OnUnchanged(GameObject weaponModel)
    {
        WeaponModel = weaponModel;
    }

    private static void OnCoinsAmountChanging(int amount)
    {
        if (CoinsToAdd + amount < 0)
            throw new Exception("CoinsToAdd can't be less 0");

        CoinsToAdd += amount;
    }
}
