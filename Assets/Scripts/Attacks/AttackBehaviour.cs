using UnityEngine;

public abstract class AttackBehaviour : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] protected float _damage;

    public abstract void PerformAttack();
}
