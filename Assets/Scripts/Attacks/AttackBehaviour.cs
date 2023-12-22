using UnityEngine;

public abstract class AttackBehaviour : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int _damage;

    public int Damage => _damage;

    public abstract void PerformAttack();
}
