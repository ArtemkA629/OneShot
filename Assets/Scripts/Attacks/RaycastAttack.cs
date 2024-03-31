using NTC.Pool;
using System;
using Random = UnityEngine.Random;
using UnityEngine;

public class RaycastAttack : AttackBehaviour, IDisposable
{
    private readonly RaycastAttackSettings _settings;
    private readonly WeaponModel _weaponModel;

    public RaycastAttack(int damage, RaycastAttackSettings settings, WeaponModel weaponModel) : base(damage)
    {
        _settings = settings;
        _weaponModel = weaponModel;
    }

    public override void PerformAttack(Transform transform)
    {
        for (var i = 0; i < _settings.ShotCount; i++)
	        PerformRaycast(transform);

        PerformEffects();

        _settings.ShakeCameraOnWeaponAttack.ReactOnAttack();
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
                damageable.ApplyDamage(Damage);
                SpawnParicleEffectsOnHit(hitInfo);
            }
        }
    }

    private void PerformEffects() 
    {
        var muzzleEffect = _weaponModel.MuzzleEffect;
        if (muzzleEffect != null)
            muzzleEffect.Play();
        if (_settings.AudioSource != null)
            _settings.AudioSource.PlayOneShot(_settings.ShotAudioClip);
    }

    private void SpawnParicleEffectsOnHit(RaycastHit hitInfo)
    {
        var hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
        var hitEffect = NightPool.Spawn(_settings.HitEffect, hitInfo.point, hitEffectRotation);
        NightPool.Despawn(hitEffect, _settings.HitEffectDestroyDelay);
    }

    private Vector3 CalculateSpread()
    {
        float spread = _settings.SpreadFactor;

        return new Vector3
        {
            x = Random.Range(-spread, spread),
            y = Random.Range(-spread, spread),
            z = Random.Range(-spread, spread)
        };
    }
}
