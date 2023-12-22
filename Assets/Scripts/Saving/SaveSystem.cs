using UnityEngine;

public class SaveSystem
{
    private const string _coinsAmount = "CoinsAmount";
    private const string _currentWeaponIndex = "CurrentWeaponIndex";
    private const string _chosenWeaponIndex = "ChosenWeaponIndex";
    private const string _weaponCard = "WeaponCard";

    private int _weaponItemsLength;

    public SaveSystem(int weaponItemsLength)
    {
        _weaponItemsLength = weaponItemsLength;
    }

    public void Save(SaveData saveData)
    {
        PlayerPrefs.SetInt(_coinsAmount, saveData.CoinsAmount);
        PlayerPrefs.SetInt(_currentWeaponIndex, saveData.CurrentWeaponIndex);
        PlayerPrefs.SetInt(_chosenWeaponIndex, saveData.ChosenWeaponIndex);

        var texts = saveData.WeaponCardTexts;
        for (int i = 0; i < texts.Length; i++)
            PlayerPrefs.SetString(_weaponCard + i, texts[i]);
    }

    public SaveData Load()
    {
        var data = new SaveData();

        var weaponCardTexts = new string[_weaponItemsLength];
        for (int i = 0; i < _weaponItemsLength; i++)
            weaponCardTexts[i] = PlayerPrefs.GetString(_weaponCard + i);
        data.WeaponCardTexts = weaponCardTexts;

        data.CurrentWeaponIndex = PlayerPrefs.GetInt(_currentWeaponIndex);
        data.ChosenWeaponIndex = PlayerPrefs.GetInt(_chosenWeaponIndex);
        data.CoinsAmount = PlayerPrefs.GetInt(_coinsAmount);

        return data;
    }
}
