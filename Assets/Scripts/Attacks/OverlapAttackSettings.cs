using System;
using UnityEngine;

[Serializable]
public class OverlapAttackSettings
{
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

    public LayerMask SearchLayerMask => _searchLayerMask;
    public LayerMask ObstacleLayerMask => _obstacleLayerMask;
    public Transform OverlapStartPoint => _overlapStartPoint;
    public OverlapType OverlapType => _overlapType;
    public Vector3 Offset => _offset;
    public Vector3 BoxSize => _boxSize;
    public float SphereRadius => _sphereRadius;
    public bool ConsiderObstacles => _considerObstacles;
}
