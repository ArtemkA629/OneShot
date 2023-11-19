using System;
using UnityEngine;

public class Enemy : Damageable
{
    [SerializeField] private Collider[] _enemyColliders;
    [SerializeField] private float _deathDelay = 4f;

    private Animator _animator;

    public static event Action<int> CoinsAmountChanging;
    public static event Action<Vector3> CoinViewing;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void OnDead()
    {
        _animator.SetTrigger(EnemyAnimatorConstants.Dead);

        foreach (var collider in _enemyColliders)
            collider.enabled = false;
        Destroy(gameObject, _deathDelay);

        int amount = 1;
        CoinsAmountChanging?.Invoke(amount);
        CoinViewing?.Invoke(transform.position);
    }
}
