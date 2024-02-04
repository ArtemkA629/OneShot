using System;
using UnityEngine;

public class DataDeletionButtonCreator : MonoBehaviour
{
    public event Action ButtonClicked;

    [ContextMenu("DeleteSavedData")]
    private void DeleteSavedData()
    {
        PlayerPrefs.DeleteAll();
        ButtonClicked?.Invoke();
    }
}
