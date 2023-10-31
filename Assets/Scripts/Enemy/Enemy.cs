using UnityEngine;

public class Enemy : Damageable
{
    [SerializeField] private Collider[] _enemyColliders;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void OnDead()
    {
        _animator.SetTrigger(EnemyAnimatorConstStrings.Dead);

        foreach (var collider in _enemyColliders)
            collider.enabled = false;
    }
}
