using UnityEngine;

public class GlobalDataHolder : MonoBehaviour
{
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
        CoinsToAdd += amount;
    }
}
