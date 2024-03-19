using System;
using UnityEngine;

public class DataDeletion : MonoBehaviour
{
    public event Action ButtonClicked;

    [ContextMenu("DeleteSavedData")]
    private void DeleteSavedData()
    {
        PlayerPrefs.DeleteAll();
        ButtonClicked?.Invoke();
    }
}
