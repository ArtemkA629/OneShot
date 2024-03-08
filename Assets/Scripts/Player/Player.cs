using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : Damageable, IAttackable
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private FootstepsSoundPlayer _soundPlayer;
    [SerializeField] private RaycastAttackSettings _settings;

    private PlayerInput _playerInput;
    private AttackBehaviour _attack;
    private Vector2 _moveDirection;

    protected override void Awake()
    {
        base.Awake();
        _playerInput = new PlayerInput();
        _attack = new RaycastAttack(_settings);
        _playerInput.Player.Jump.performed += ctx => _movement.TryJump();
        _playerInput.Player.Attack.performed += ctx => Attack();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _playerInput.Enable();
    }

    private void Update()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();                                                     
        _movement.Move(_moveDirection);
        _soundPlayer.Play();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
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
