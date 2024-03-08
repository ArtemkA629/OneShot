using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] private int _maxHealthAmount;

    private Health _health;

    public event Action Dead;

    public Health Health => _health;
    public int MaxHealthAmount => _maxHealthAmount;

    protected virtual void Awake()
    {
        _health = new Health(_maxHealthAmount);
        Debug.Log(_maxHealthAmount);
    }

    protected virtual void OnEnable()
    {
        Dead += OnDead;
    }

    protected virtual void OnDisable()
    {
        Dead -= OnDead;
    }

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _health.SubtractAmount(damage);
        if (_health.Amount == 0)
            Dead?.Invoke();
    }

    protected abstract void OnDead();
}
