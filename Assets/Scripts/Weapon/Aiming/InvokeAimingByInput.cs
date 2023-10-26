using UnityEngine;

public class InvokeAimingByInput : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _initialFieldOfView = 60f;
    [SerializeField, Min(0f)] private float _changedFieldOfView = 50f;
    [SerializeField, Min(0f)] private float _duration = 0.3f;

    private WeaponAiming _weaponAiming;

    private void Start()
    {
        _weaponAiming = GetComponent<WeaponAiming>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            _weaponAiming.AnimateAiming(true, _changedFieldOfView, _duration);
        if (Input.GetMouseButtonUp(1))
            _weaponAiming.AnimateAiming(false, _initialFieldOfView, _duration);
    }
}
