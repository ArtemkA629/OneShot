using UnityEngine;

public class RotateCameraByInput : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform _playerTransform;

    [Header("Characteristics")]
    [SerializeField, Min(0f)] private float _cameraSensitivity = 2f;
    [SerializeField, Min(0f)] private float _maxYAngle = 80f;

    private PlayerInput _playerInput;
    private Vector2 _lookDirection;
    private float _rotationX = 0f;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void Update()
    {
        _lookDirection = _playerInput.Camera.Look.ReadValue<Vector2>();
        Look();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Look()
    {
        _rotationX -= _lookDirection.y * _cameraSensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        _playerTransform.Rotate(Vector3.up * _lookDirection.x * _cameraSensitivity);
    }
}
