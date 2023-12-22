using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] private int _maxHealthAmount;

    public Health Health { get; private set; }
    public int MaxHealthAmount => _maxHealthAmount;

    public event Action Dead;

    private void Awake()
    {
        Health = new Health(_maxHealthAmount);
    }

    private void OnEnable()
    {
        Dead += OnDead;
    }

    private void OnDisable()
    {
        Dead -= OnDead;
    }

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Health.SubtractAmount(damage);

        if (Health.Amount == 0)
            Dead?.Invoke();
    }

    protected abstract void OnDead();
}
