using UnityEngine;

public class WeaponModelChanger : MonoBehaviour
{
    [SerializeField] private Transform _parent;

    private void Awake()
    {
        Instantiate(GlobalDataHolder.WeaponModel, _parent, false);
    }
}