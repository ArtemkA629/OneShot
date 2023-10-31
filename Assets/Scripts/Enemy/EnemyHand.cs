using UnityEngine;

public class EnemyHand : MonoBehaviour
{
    [SerializeField] private OverlapAttack _overlapAttack;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
            _overlapAttack.PerformAttack();
    }
}
