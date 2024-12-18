using UnityEngine;

public class EnemyHand : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player _))
            _enemy.Attack();
    }
}
