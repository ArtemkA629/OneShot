using UnityEngine;

public class InvokeAimingByInput : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _initialFieldOfView = 60f;
    [SerializeField, Min(0f)] private float _changedFieldOfView = 50f;
    [SerializeField, Min(0f)] private float _duration = 0.3f;

    private WeaponAiming _weaponAiming;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _weaponAiming = GetComponent<WeaponAiming>();
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void Update()
    {
        if (_playerInput.Weapon.Aim.WasPressedThisFrame())
            _weaponAiming.Animate(true, _changedFieldOfView, _duration);
        if (_playerInput.Weapon.Aim.WasReleasedThisFrame())
            _weaponAiming.Animate(false, _initialFieldOfView, _duration);
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
