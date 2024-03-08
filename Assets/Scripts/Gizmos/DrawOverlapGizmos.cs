using System;
using UnityEngine;

public class DrawOverlapGizmos : MonoBehaviour
{
    [SerializeField] private Transform _overlapStartPoint;
    [SerializeField] private OverlapType _overlapType;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _boxSize = Vector3.one;
    [SerializeField, Min(0f)] private float _sphereRadius = 1f;
    [SerializeField] private DrawGizmosType _drawGizmosType;
    [SerializeField] private Color _gizmosColor = Color.cyan;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        TryDrawGizmos(DrawGizmosType.Always);
    }

    private void OnDrawGizmosSelected()
    {
        TryDrawGizmos(DrawGizmosType.OnSelected);
    }

    private void TryDrawGizmos(DrawGizmosType requiredType)
    {
        if (_drawGizmosType != requiredType || _overlapStartPoint == null)
            return;

        Gizmos.matrix = _overlapStartPoint.localToWorldMatrix;
        Gizmos.color = _gizmosColor;

        switch (_overlapType)
        {
            case OverlapType.Box:
                Gizmos.DrawCube(_offset, _boxSize);
                break;
            case OverlapType.Sphere:
                Gizmos.DrawSphere(_offset, _sphereRadius);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(_overlapType));
        }
    }
#endif
}
