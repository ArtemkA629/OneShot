using System;
using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public SavesYG() { }

        public SavesYG(SaveData saveData)
        {
            WeaponCardTexts = saveData.WeaponCardTexts;
            CurrentWeaponIndex = saveData.CurrentWeaponIndex;
            ChosenWeaponIndex = saveData.ChosenWeaponIndex;
            CoinsAmount = saveData.CoinsAmount;
        }

        // Ваши сохранения

        public int CurrentWeaponIndex;
        public int ChosenWeaponIndex;
        public int CoinsAmount;
        public string[] WeaponCardTexts;
    }
}
