using System;
using UnityEngine;

public class SaveData
{
    private int _currentWeaponIndex;
    private int _chosenWeaponIndex;
    private int _coinsAmount;

    public int CurrentWeaponIndex
    {
        get { return _currentWeaponIndex; }
        set { _currentWeaponIndex = Mathf.Clamp(value, 0, WeaponCardTexts.Length - 1); }
    }

    public int ChosenWeaponIndex
    {
        get { return _chosenWeaponIndex; }
        set { _chosenWeaponIndex = Mathf.Clamp(value, 0, WeaponCardTexts.Length - 1); }
    }

    public int CoinsAmount
    {
        get { return _coinsAmount; }
        set { _coinsAmount = Mathf.Clamp(value, 0, int.MaxValue); }
    }

    public string[] WeaponCardTexts;

    public void SetWeaponCardTexts(WeaponCard[] _weaponCards)
    {
        if (WeaponCardTexts.Length != _weaponCards.Length)
            throw new Exception("Invalid weapon cards length");

        for (int i = 0; i < WeaponCardTexts.Length; i++)
            WeaponCardTexts[i] = _weaponCards[i].CardText;
    }

    public bool WasEverSaved()
    {
        return WeaponCardTexts[0] != null;
    }

    public void ResetIndexes()
    {
        CurrentWeaponIndex = 0;
        ChosenWeaponIndex = 0;
    }
}
