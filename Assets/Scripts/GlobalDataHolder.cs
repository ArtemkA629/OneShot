using System;
using UnityEngine;

public static class GlobalDataHolder
{
    public static LevelDifficulty LevelDifficulty { get; private set; }
    public static WeaponModel WeaponModel { get; private set; }
    public static int CoinsToAdd { get; private set; }

    static GlobalDataHolder()
    {
        GameLoader.LevelChosen += OnLevelChosen;
        WeaponCard.Unchanged += OnUnchanged;
        Enemy.CoinsAmountChanging += OnCoinsAmountChanging;
    }

    public static void ResetCoinsAmount()
    {
        CoinsToAdd = 0;
    }

    public static void SetCurrentWeaponModel(WeaponModel weaponModel)
    {
        WeaponModel = weaponModel;
    }

    private static void OnLevelChosen(LevelDifficulty levelDifficulty)
    {
        LevelDifficulty = levelDifficulty;
    }

    private static void OnUnchanged(WeaponModel weaponModel)
    {
        SetCurrentWeaponModel(weaponModel);
    }

    private static void OnCoinsAmountChanging(int amount)
    {
        if (CoinsToAdd + amount < 0)
            throw new Exception("CoinsToAdd can't be less 0");

        CoinsToAdd += amount;
    }
}
