using NTC.Pool;
using System;
using UnityEngine;

public class Enemy : Damageable, IAttackable
{
    [SerializeField] private Collider[] _enemyColliders;
    [SerializeField] private float _deathDelay = 4f;

    private Animator _animator;
    private AttackBehaviour _attack;

    public static event Action<int> CoinsAmountChanging;
    public static event Action<Vector3> CoinViewing;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _attack = GetComponent<AttackBehaviour>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        if (Health.Amount == MaxHealthAmount)
            return;

        Health.SetAmount(MaxHealthAmount);
        foreach (var collider in _enemyColliders)
            collider.enabled = true;
    }

    protected override void OnDead()
    {
        _animator.SetTrigger(EnemyAnimatorConstants.Dead);

        foreach (var collider in _enemyColliders)
            collider.enabled = false;

        int amount = 1;
        CoinsAmountChanging?.Invoke(amount);
        CoinViewing?.Invoke(transform.position);

        NightPool.Despawn(this, _deathDelay);
    }

    public void Attack()
    {
        _attack.PerformAttack();
    }
}
