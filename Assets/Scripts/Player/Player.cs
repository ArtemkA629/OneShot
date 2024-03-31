using System;
using UnityEngine;

public class Player : Damageable, IAttackable
{
    [SerializeField] private FootstepsSoundPlayer _soundPlayer;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private RaycastAttackSettings _settings;

    private PlayerInput _playerInput;
    private AttackBehaviour _attack;
    private Vector2 _moveDirection;
    private WeaponModel _weaponModel;

    public event Action GameOver;

    protected override void Awake()
    {
        base.Awake();
        _playerInput = new PlayerInput();
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
        _movement.Move(_moveDirection, transform);
        _soundPlayer.Play();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _playerInput.Disable();
        _attack.Dispose();
    }

    public void Attack()
    {
        _attack.PerformAttack(transform);
    }

    public void SetModel(WeaponModel weaponModel)
    {
        _weaponModel = weaponModel;
        SetAttack();
    }

    protected override void OnDead()
    {
        GameOver?.Invoke();
    }

    private void SetAttack()
    {
        var damage = _weaponModel.Damage;
        _attack = new RaycastAttack(damage, _settings, _weaponModel);
    }
}
