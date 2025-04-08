using YG;

public class YGSaveSystem : ISaveSystem
{
    private readonly int _weaponItemsLength;

    public YGSaveSystem(int weaponItemsLength)
    {
        _weaponItemsLength = weaponItemsLength;
    }

    public void Save(SaveData saveData)
    {
        YandexGame.savesData = new SavesYG(saveData);
        YandexGame.SaveProgress();
    }

    public SaveData Load()
    {
        YandexGame.savesData.WeaponCardTexts ??= new string[_weaponItemsLength];
        return new SaveData(YandexGame.savesData);
    }
}
