using UnityEngine;

public class RotateCameraByInput : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform _player;

    [Header("Characteristics")]
    [SerializeField, Min(0f)] private float _cameraSensitivity = 2f;
    [SerializeField, Min(0f)] private float _maxYAngle = 80f;

    private float _rotationX = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis(Axis.MouseX) * _cameraSensitivity;
        float mouseY = Input.GetAxis(Axis.MouseY) * _cameraSensitivity;

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);

        transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        _player.Rotate(Vector3.up * mouseX);
    }
}
