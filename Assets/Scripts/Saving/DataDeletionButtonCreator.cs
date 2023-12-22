using System;
using UnityEngine;

public class DataDeletionButtonCreator : MonoBehaviour
{
#if UNITY_EDITOR
    public Action ButtonClicked;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(50f, 0f, 100f, 30f), "Delete"))
        {
            PlayerPrefs.DeleteAll();
            ButtonClicked?.Invoke();
        }
    }
#endif
}
