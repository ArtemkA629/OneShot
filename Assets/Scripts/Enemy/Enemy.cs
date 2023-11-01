using System;
using UnityEngine;

public class Enemy : Damageable
{
    [SerializeField] private Collider[] _enemyColliders;

    private Animator _animator;

    public static event Action<int> CoinsAmountChanging;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void OnDead()
    {
        _animator.SetTrigger(EnemyAnimatorConstStrings.Dead);

        foreach (var collider in _enemyColliders)
            collider.enabled = false;

        int amount = 1;
        CoinsAmountChanging?.Invoke(amount);
    }
}
