using System.Collections.Generic;
using UnityEngine;

public static class GameDataHolder
{
    [SerializeField] private Dictionary<Sprite, GameObject> _weapons;

    public static GameObject CurrentModel { get; private set; }
    public static LevelDifficulty LevelDifficulty { get; private set; }

    public static SetLevel(LevelDifficulty levelDifficulty)
    {
        LevelDifficulty = levelDifficulty;
    }

    private void OnEnable()
    {
        WeaponCard.Unchanged += OnUnchanged;
    }

    private void OnDisable()
    {
        WeaponCard.Unchanged -= OnUnchanged;
    }

    private void OnUnchanged(Sprite weaponSprite)
    {
        CurrentModel = _weapons[weaponSprite];
    }
}
