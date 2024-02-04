using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] private int _maxHealthAmount;

    private Health _health;

    public Health Health => _health;
    public int MaxHealthAmount => _maxHealthAmount;

    public event Action Dead;

    protected void OnAwake()
    {
        _health = new Health(_maxHealthAmount);
        Debug.Log(_maxHealthAmount);
    }

    protected void Enable()
    {
        Dead += OnDead;
    }

    protected void Disable()
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
