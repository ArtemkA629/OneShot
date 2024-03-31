using System;
using UnityEngine;

public class OverlapAttack : AttackBehaviour
{
    private readonly Collider[] _overlapResults = new Collider[32];
    private readonly OverlapAttackSettings _settings;

    private int _overlapResultsCount;

    public OverlapAttack(int damage, OverlapAttackSettings settings) : base(damage)
    {
        _settings = settings;
    }

    public override void PerformAttack()
    {
        if (TryFindEnemies())
            TryAttackEnemies();
    }

    private bool TryFindEnemies()
    {
        var position = _settings.OverlapStartPoint.TransformPoint(_settings.Offset);

        _overlapResultsCount = _settings.OverlapType switch
        {
            OverlapType.Box => OverlapBox(position),
            OverlapType.Sphere => OverlapSphere(position),
            _ => throw new ArgumentOutOfRangeException(nameof(_settings.OverlapType))
        };

        return _overlapResultsCount > 0;                                                                                                                                                                                                      
    }

    private int OverlapBox(Vector3 position)
    {
        return Physics.OverlapBoxNonAlloc(position, _settings.BoxSize / 2, _overlapResults,
            _settings.OverlapStartPoint.rotation, _settings.SearchLayerMask.value);
    }

    private int OverlapSphere(Vector3 position)
    {
        return Physics.OverlapSphereNonAlloc(position, _settings.SphereRadius, _overlapResults, _settings.SearchLayerMask.value);
    }

    private void TryAttackEnemies()
    {
        for (int i = 0; i < _overlapResultsCount; i++)
        {
            if (_overlapResults[i].TryGetComponent(out Damageable damageable) == false)
                continue;

            if (_settings.ConsiderObstacles)
            {
                var startPointPosition = _settings.OverlapStartPoint.position;
                var colliderPosition = _overlapResults[i].transform.position;
                var hasObstacle = Physics.Linecast(startPointPosition, colliderPosition, _settings.ObstacleLayerMask.value);

                if (hasObstacle)
                    continue;
            }

            damageable.ApplyDamage(Damage);
        }
    }
}
