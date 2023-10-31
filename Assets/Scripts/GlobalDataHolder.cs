using UnityEngine;

public class GlobalDataHolder : MonoBehaviour
{
    public static LevelDifficulty LevelDifficulty { get; private set; }
    public static GameObject WeaponModel { get; private set; }

    private void OnEnable()
    {
        LevelButton.LevelChosen += OnLevelChosen;
        WeaponCard.Unchanged += OnUnchanged;
        
    }

    private void OnLevelChosen(LevelDifficulty levelDifficulty)
    {
        LevelDifficulty = levelDifficulty;
        LevelButton.LevelChosen -= OnLevelChosen;
    }

    private void OnUnchanged(GameObject weaponModel)
    {
        WeaponModel = weaponModel;
        WeaponCard.Unchanged -= OnUnchanged;
    }
}
