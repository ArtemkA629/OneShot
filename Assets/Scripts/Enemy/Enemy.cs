using NTC.Pool;
using System;
using UnityEngine;
using Zenject;

public class Enemy : Damageable, IDespawnable
{
    [SerializeField] private Collider[] _enemyColliders;
    [SerializeField] private float _deathDelay = 4f;

    private Animator _animator;
    private Spawner _spawner;

    public static event Action<int> CoinsAmountChanging;
    public static event Action<Vector3> CoinViewing;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spawner = FindAnyObjectByType<Spawner>();
    }

    protected override void OnDead()
    {
        _animator.SetTrigger(EnemyAnimatorConstants.Dead);

        foreach (var collider in _enemyColliders)
            collider.enabled = false;

        int amount = 1;
        CoinsAmountChanging?.Invoke(amount);
        CoinViewing?.Invoke(transform.position);

        _spawner.ApplyDespawn(gameObject, _deathDelay);
        OnDespawn();
    }

    public void OnDespawn()
    {
        Health = MaxHealth;

        foreach (var collider in _enemyColliders)
            collider.enabled = true;
    }
}
