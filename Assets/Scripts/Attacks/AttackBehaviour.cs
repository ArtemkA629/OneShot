using System;
using UnityEngine;

public abstract class AttackBehaviour : IDisposable
{
    public virtual void PerformAttack() { }
    public virtual void PerformAttack(Transform transform) { }
    public virtual void Dispose() { }
}
