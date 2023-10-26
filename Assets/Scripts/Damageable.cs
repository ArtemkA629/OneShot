using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;

    public float Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0f, int.MaxValue);
    }

    public event Action Dead;

    private void OnEnable()
    {
        Dead += OnDead;
    }

    private void OnDisable()
    {
        Dead -= OnDead;
    }

    public void ApplyDamage(float damage)
    {
        if (damage < 0f)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Health -= damage;

        if (Health == 0f)
            Dead?.Invoke();
    }

    protected abstract void OnDead();
}
