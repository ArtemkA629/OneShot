using System;
using UnityEngine;

[Serializable]
public class PlayerMovement
{
    [Header("Check Grounded")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField, Min(0f)] private float _checkRadius;

    [Header("Characteristics")]
    [SerializeField, Min(0f)] private float _speed = 5f;
    [SerializeField, Min(0f)] private float _jumpForce = 10f;
    [SerializeField, Min(0f)] private float _stepDistance;

    [Header("Audio")]
    [SerializeField] private AudioSource _stepsAudioSource;

    [SerializeField] private Rigidbody _rigidbody;

    public void Move(Vector2 moveDirection, Transform transform)
    {
        if (moveDirection.sqrMagnitude < 0.1f)
            return;

        Vector3 movement = new Vector3(moveDirection.x, 0f, moveDirection.y);
        transform.Translate(movement * _speed * Time.deltaTime);
    }

    public void TryJump()
    {
        if (Grounded())
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private bool Grounded()
    {
        return Physics.CheckSphere(_groundCheck.position, _checkRadius, _groundLayerMask);
    }
}
