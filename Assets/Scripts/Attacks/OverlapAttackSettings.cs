using System;
using UnityEngine;

[Serializable]
public class OverlapAttackSettings
{
    [Header("Damage")]
    [SerializeField] private int _damage;

    [Header("Masks")]
    [SerializeField] private LayerMask _searchLayerMask;
    [SerializeField] private LayerMask _obstacleLayerMask;

    [Header("Overlap Area")]
    [SerializeField] private Transform _overlapStartPoint;
    [SerializeField] private OverlapType _overlapType;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _boxSize = Vector3.one;
    [SerializeField, Min(0f)] private float _sphereRadius = 1f;

    [Header("Obstacles")]
    [SerializeField] private bool _considerObstacles;
}
