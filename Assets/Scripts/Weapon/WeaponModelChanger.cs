using UnityEngine;

public class WeaponModelChanger : MonoBehaviour
{
    [SerializeField] private Transform _parent;

    private void Start()
    {
        Instantiate(GlobalDataHolder.WeaponModel, _parent, false);
    }
}
