using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class RaycastAttackSettings
{
    [Header("Damage")]
    [SerializeField] private int _damage;

    [Header("Ray")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Min(0f)] private float _distance = Mathf.Infinity;
    [SerializeField, Min(0)] private int _shotCount = 1;

    [Header("Spread")]
    [SerializeField] private bool _useSpread;
    [SerializeField, Min(0f)] private float _spreadFactor = 1f;

    [Header("Particle System")]
    [SerializeField] private AssetReference _hitEffectReference;
    [SerializeField, Min(0f)] private float _hitEffectDestroyDelay = 2f;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AssetReference _shotAudioClipReference;

    public int Damage => _damage;
    public LayerMask LayerMask => _layerMask;
    public float Distance => _distance;
    public int ShotCount => _shotCount;

    public bool UseSpread => _useSpread;
    public float SpreadFactor => _spreadFactor;
    public AssetReference HitEffectReference => _hitEffectReference;
    public float HitEffectDestroyDelay => _hitEffectDestroyDelay;
    public AudioSource AudioSource => _audioSource;
    public AssetReference ShotAudioClipReference => _shotAudioClipReference;
}
