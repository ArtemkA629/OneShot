using System;
using UnityEngine;
using YG;

public class DataDeletion : MonoBehaviour
{
    public event Action ButtonClicked;

    [ContextMenu("DeleteSavedData")]
    private void DeleteSavedData()
    {
        PlayerPrefs.DeleteAll();
        YandexGame.ResetSaveProgress();
        ButtonClicked?.Invoke();
    }
}
