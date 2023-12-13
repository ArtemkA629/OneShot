using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth;

    public float Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0f, float.MaxValue);
    }

    public float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = Mathf.Clamp(value, 0f, float.MaxValue);
    }

    public event Action Dead;

    private void OnEnable()
    {
        Dead += OnDead;

        _maxHealth = _health;
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
