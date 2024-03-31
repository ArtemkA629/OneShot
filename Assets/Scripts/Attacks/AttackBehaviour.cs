using System;
using UnityEngine;

public abstract class AttackBehaviour : IDisposable
{
    private readonly int _damage;

    protected int Damage => _damage;

    public AttackBehaviour(int damage)
    {
        _damage = damage;
    }

    public virtual void PerformAttack() { }
    public virtual void PerformAttack(Transform transform) { }
    public virtual void Dispose() { }
}
