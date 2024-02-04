using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : Damageable, IAttackable
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private AttackBehaviour _attack;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private FootstepsSoundPlayer _soundPlayer;

    private PlayerInput _playerInput;
    private Vector2 _moveDirection;

    private void Awake()
    {
        base.OnAwake();
        _playerInput = new PlayerInput();
        _playerInput.Player.Jump.performed += ctx => _movement.TryJump();
        _playerInput.Player.Attack.performed += ctx => Attack();
    }

    private void OnEnable()
    {
        base.Enable();
        _playerInput.Enable();
    }

    private void Update()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();                                                     
        _movement.Move(_moveDirection);
        _soundPlayer.Play();
    }

    private void OnDisable()
    {
        base.Disable();
        _playerInput.Disable();
    }

    protected override void OnDead()
    {
        _gameOver.Stop();
    }

    public void Attack()
    {
        _attack.PerformAttack();
    }
}
