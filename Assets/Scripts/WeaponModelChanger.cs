using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WeaponModelChanger : ScriptableObject
{
    private Dictionary<Sprite, GameObject> _weapons;

    public GameObject CurrentModel { get; private set; }

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
