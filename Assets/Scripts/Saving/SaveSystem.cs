using UnityEngine;

public class SaveSystem
{
    public const string CoinsAmount = "CoinsAmount";
    public const string CurrentWeaponIndex = "CurrentWeaponIndex";
    public const string ChosenWeaponIndex = "ChosenWeaponIndex";
    public const string WeaponCard = "WeaponCard";

    private int _weaponItemsLength;

    public SaveSystem(int weaponItemsLength)
    {
        _weaponItemsLength = weaponItemsLength;
    }

    public void Save(SaveData saveData)
    {
        PlayerPrefs.SetInt(CoinsAmount, saveData.CoinsAmount);
        PlayerPrefs.SetInt(CurrentWeaponIndex, saveData.CurrentWeaponIndex);
        PlayerPrefs.SetInt(ChosenWeaponIndex, saveData.ChosenWeaponIndex);

        var texts = saveData.WeaponCardTexts;
        for (int i = 0; i < texts.Length; i++)
            PlayerPrefs.SetString(WeaponCard + i, texts[i]);
    }

    public SaveData Load()
    {
        var data = new SaveData();

        var weaponCardTexts = new string[_weaponItemsLength];
        for (int i = 0; i < _weaponItemsLength; i++)
            weaponCardTexts[i] = PlayerPrefs.GetString(WeaponCard + i);
        data.WeaponCardTexts = weaponCardTexts;

        data.CurrentWeaponIndex = PlayerPrefs.GetInt(CurrentWeaponIndex);
        data.ChosenWeaponIndex = PlayerPrefs.GetInt(ChosenWeaponIndex);
        data.CoinsAmount = PlayerPrefs.GetInt(CoinsAmount);

        return data;
    }
}
