using System;
using UnityEngine;

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
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField, Min(0f)] private float _hitEffectDestroyDelay = 2f;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shotAudioClip;

    public int Damage => _damage;
    public LayerMask LayerMask => _layerMask;
    public float Distance => _distance;
    public int ShotCount => _shotCount;
    public bool UseSpread => _useSpread;
    public float SpreadFactor => _spreadFactor;
    public ParticleSystem HitEffect => _hitEffect;
    public float HitEffectDestroyDelay => _hitEffectDestroyDelay;
    public AudioSource AudioSource => _audioSource;
    public AudioClip ShotAudioClip => _shotAudioClip;
}
