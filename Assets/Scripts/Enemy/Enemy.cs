using NTC.Pool;
using System;
using UnityEngine;

public class Enemy : Damageable, IAttackable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _deathDelay = 4f;
    [SerializeField] private float _attackRange = 1.75f;
    [SerializeField] private int _damage;
    [SerializeField] private Collider[] _enemyColliders;
    [SerializeField] private OverlapAttackSettings _settings;
    
    private AttackBehaviour _attack;

    public static event Action<int> CoinsAmountChanging;
    public static event Action<Vector3> CoinViewing;

    public float AttackRange => _attackRange;

    protected override void Awake()
    {
        base.Awake();
        _attack = new OverlapAttack(_damage, _settings);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        ResetSettings();
    }

    protected override void OnDead()
    {
        AnimateDeath();
        OffColliders();
        AddCoin();
        Destroy();
    }

    public void Attack()
    {
        _attack.PerformAttack();
    }

    private void ResetSettings()
    {
        if (Health.Amount == MaxHealthAmount)
            return;

        Health.SetAmount(MaxHealthAmount);
        foreach (var collider in _enemyColliders)
            collider.enabled = true;
    }
    private void AnimateDeath()
    {
        _animator.SetTrigger(EnemyAnimatorConstStrings.Dead);
    }

    private void OffColliders()
    {
        foreach (var collider in _enemyColliders)
            collider.enabled = false;
    }

    private void AddCoin()
    {
        int amount = 1;
        CoinsAmountChanging?.Invoke(amount);
        CoinViewing?.Invoke(transform.position);
    }

    private void Destroy()
    {
        NightPool.Despawn(this, _deathDelay);
    }
}
