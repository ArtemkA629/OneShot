using UnityEngine;

public class WeaponModelChanger : MonoBehaviour
{
    private void Start()
    {
        SetModelActive(true);
    }

    private void OnDestroy()
    {
        SetModelActive(false);
    }

    private void SetModelActive(bool value)
    {
        Debug.Log(GlobalDataHolder.WeaponModel.name);
        GameObject.Find(GlobalDataHolder.WeaponModel.name).SetActive(value);
    }
}
