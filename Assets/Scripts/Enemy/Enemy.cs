using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Damageable
{
    [SerializeField] private Collider[] _enemyColliders;
    [SerializeField] private float _deathDelay = 4f;

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    public static event Action<int> CoinsAmountChanging;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected override void OnDead()
    {
        _animator.SetTrigger(EnemyAnimatorConstStrings.Dead);
        _navMeshAgent.SetDestination(transform.position);

        foreach (var collider in _enemyColliders)
            collider.enabled = false;
        Destroy(gameObject, _deathDelay);

        int amount = 1;
        CoinsAmountChanging?.Invoke(amount);
    }
}
