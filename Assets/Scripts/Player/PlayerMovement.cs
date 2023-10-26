using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Check Grounded")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField, Min(0f)] private float _checkRadius;

    [Header("Characteristics")]
    [SerializeField, Min(0f)] private float _speed = 5f;
    [SerializeField, Min(0f)] private float _jumpForce = 10f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(Axis.Horizontal);
        float verticalInput = Input.GetAxis(Axis.Vertical);

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(movement * _speed * Time.deltaTime);
    }

    private bool Grounded()
    {
        return Physics.CheckSphere(_groundCheck.position, _checkRadius, _groundLayerMask);
    }
}
