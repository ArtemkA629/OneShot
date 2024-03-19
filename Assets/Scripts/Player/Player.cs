using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : Damageable, IAttackable
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private FootstepsSoundPlayer _soundPlayer;
    [SerializeField] private WeaponModelSpawner _weaponModelChanger;
    [SerializeField] private ShakeCameraOnWeaponAttack _shakeCameraOnWeaponAttack;
    [SerializeField] private RaycastAttackSettings _settings;

    private PlayerInput _playerInput;
    private AttackBehaviour _attack;
    private Vector2 _moveDirection;
    private WeaponModel _weaponModel;

    private WeaponModel WeaponModel { set { if (value.TryGetComponent(out WeaponModel _)) _weaponModel = value; } }

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
        _movement.Move(_moveDirection);
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
        WeaponModel = weaponModel;
        SetAttack();
    }

    protected override void OnDead()
    {
        _gameOver.Stop();
    }

    private void SetAttack()
    {
        var effect = _weaponModel.MuzzleEffect;
        _attack = new RaycastAttack(_settings, effect, _shakeCameraOnWeaponAttack);
    }
}
