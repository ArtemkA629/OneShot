using UnityEngine;

[RequireComponent(typeof(WeaponAiming))]
public class InvokeAimingByInput : MonoBehaviour
{
    [SerializeField] private WeaponAiming _weaponAiming;
    [SerializeField, Min(0f)] private float _initialFieldOfView = 60f;
    [SerializeField, Min(0f)] private float _changedFieldOfView = 50f;
    [SerializeField, Min(0f)] private float _duration = 0.3f;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void Update()
    {
        var aim = _playerInput.Weapon.Aim;
        if (aim.WasPressedThisFrame())
            _weaponAiming.Animate(true, _changedFieldOfView, _duration);
        if (aim.WasReleasedThisFrame())
            _weaponAiming.Animate(false, _initialFieldOfView, _duration);
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
