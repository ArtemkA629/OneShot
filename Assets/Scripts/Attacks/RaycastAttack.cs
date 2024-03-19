using NTC.Pool;
using System;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class RaycastAttack : AttackBehaviour, IDisposable
{
    private readonly RaycastAttackSettings _settings;
    private readonly IWeaponAttackReaction _shakeCameraOnWeaponAttack;
    private readonly ParticleSystem _muzzleEffect;

    private GameObject _hitEffectPrefab;
    private AudioClip _shotAudioClip;

    public RaycastAttack(RaycastAttackSettings settings, ParticleSystem effect, IWeaponAttackReaction reaction)
    {
        _settings = settings;
        _muzzleEffect = effect;
        _shakeCameraOnWeaponAttack = reaction;
    }

    public override void Dispose()
    {
        if (_hitEffectPrefab != null)
            Addressables.Release(_hitEffectPrefab);
        if (_shotAudioClip != null)
            Addressables.Release(_shotAudioClip);
    }

    public override void PerformAttack(Transform transform)
    {
        for (var i = 0; i < _settings.ShotCount; i++)
	        PerformRaycast(transform);

        PerformEffects();

        _shakeCameraOnWeaponAttack.ReactOnAttack();
    }

    private void PerformRaycast(Transform transform)
    {
        var direction = _settings.UseSpread ? transform.forward + CalculateSpread() : transform.forward;
        var ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _settings.Distance, _settings.LayerMask))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out Damageable damageable))
            {
                damageable.ApplyDamage(_settings.Damage);
                SpawnParicleEffectsOnHit(hitInfo);
            }
        }
    }

    private async void PerformEffects()
    {
        if (_muzzleEffect != null)
            _muzzleEffect.Play();

        if (_shotAudioClip == null)
        {
            var handle = await AsyncOperationsExecutor.Load<AudioClip>(_settings.ShotAudioClipReference);
            _shotAudioClip = handle.Result;
        }

        if (_settings.AudioSource != null)
            _settings.AudioSource.PlayOneShot(_shotAudioClip);
    }

    private async void SpawnParicleEffectsOnHit(RaycastHit hitInfo)
    {
        if (_hitEffectPrefab == null)
        {
            var handle = await AsyncOperationsExecutor.Load<GameObject>(_settings.HitEffectReference);
            _hitEffectPrefab = await handle.Task;
        }

        var hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
        var hitEffect = NightPool.Spawn(_hitEffectPrefab, hitInfo.point, hitEffectRotation);
        NightPool.Despawn(hitEffect, _settings.HitEffectDestroyDelay);
    }

    private Vector3 CalculateSpread()
    {
        float spread = _settings.SpreadFactor;

        return new Vector3
        {
            x = Random.Range(-spread, spread),
            y = Random.Range(-spread, spread),
            z = Random.Range(-spread, spread
            )
        };
    }
}
