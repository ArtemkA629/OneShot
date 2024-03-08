using UnityEngine;

public class SaveSystem
{
    private readonly int _weaponItemsLength;

    public SaveSystem(int weaponItemsLength)
    {
        _weaponItemsLength = weaponItemsLength;
    }

    public void Save(SaveData saveData)
    {
        PlayerPrefs.SetInt(SaveSystemConstStrings.CoinsAmount, saveData.CoinsAmount);
        PlayerPrefs.SetInt(SaveSystemConstStrings.CurrentWeaponIndex, saveData.CurrentWeaponIndex);
        PlayerPrefs.SetInt(SaveSystemConstStrings.ChosenWeaponIndex, saveData.ChosenWeaponIndex);

        var texts = saveData.WeaponCardTexts;
        for (int i = 0; i < texts.Length; i++)
            PlayerPrefs.SetString(SaveSystemConstStrings.WeaponCard + i, texts[i]);
    }

    public SaveData Load()
    {
        var data = new SaveData();

        var weaponCardTexts = new string[_weaponItemsLength];
        for (int i = 0; i < _weaponItemsLength; i++)
            weaponCardTexts[i] = PlayerPrefs.GetString(SaveSystemConstStrings.WeaponCard + i);
        data.WeaponCardTexts = weaponCardTexts;

        data.CurrentWeaponIndex = PlayerPrefs.GetInt(SaveSystemConstStrings.CurrentWeaponIndex);
        data.ChosenWeaponIndex = PlayerPrefs.GetInt(SaveSystemConstStrings.ChosenWeaponIndex);
        data.CoinsAmount = PlayerPrefs.GetInt(SaveSystemConstStrings.CoinsAmount);

        return data;
    }
}
