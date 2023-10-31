using UnityEngine;

public class WeaponModelChanger : MonoBehaviour
{
    [SerializeField] private GameObject _weaponModel;

    private void Start()
    {
        _weaponModel = GlobalDataHolder.WeaponModel;
    }
}
