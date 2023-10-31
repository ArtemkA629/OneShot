using UnityEngine;

public class RaycastAttack : AttackBehaviour
{
    [Header("Damage")]
    [SerializeField, Min(0f)] private float _damage = 10f;

    [Header("Ray")]
    [SerializeField, Min(0f)] private LayerMask _layerMask;
    [SerializeField, Min(0f)] private float _distance = Mathf.Infinity;
    [SerializeField, Min(0f)] private int _shotCount = 1;

    [Header("Spread")]
    [SerializeField] private bool _useSpread;
    [SerializeField, Min(0f)] private float _spreadFactor = 1f;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem _muzzleEffect;
    [SerializeField] private ParticleSystem _hitEffectPrefab;
    [SerializeField, Min(0f)] private float _hitEffectDestroyDelay = 2f;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private IWeaponAttackReaction _shakeCameraOnWeaponAttack;

    private void Start()
    {
        _shakeCameraOnWeaponAttack = GetComponentInParent<IWeaponAttackReaction>();
    }

    public override void PerformAttack()
    {
        for (var i = 0; i <_shotCount; i++)
	        PerformRaycast();

        PerformEffects();

        _shakeCameraOnWeaponAttack.ReactOnAttack();
    }

    private void PerformRaycast()
    {
        var direction = _useSpread ? transform.forward + CalculateSpread() : transform.forward;
        var ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out Damageable damageable))
            {
                damageable.ApplyDamage(_damage);
                Debug.Log("Hit");
            }

            SpawnParicleEffectsOnHit(hitInfo);
        }
    }

    private void PerformEffects()
    {
        if (_muzzleEffect != null)
            _muzzleEffect.Play();

        if (_audioSource != null && _audioClip != null)
            _audioSource.PlayOneShot(_audioClip);
    }

    private void SpawnParicleEffectsOnHit(RaycastHit hitInfo)
    {
        if (_hitEffectPrefab != null)
        {
            var hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
            var hitEffect = Instantiate(_hitEffectPrefab, hitInfo.point, hitEffectRotation);

            Destroy(hitEffect.gameObject, _hitEffectDestroyDelay);
        }
    }

    private Vector3 CalculateSpread()
    {
        return new Vector3
        {
            x = Random.Range(-_spreadFactor, _spreadFactor),
            y = Random.Range(-_spreadFactor, _spreadFactor),
            z = Random.Range(-_spreadFactor, _spreadFactor)
        };
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        else
        {
            var hitPosition = ray.origin + ray.direction * _distance;
            DrawRay(ray, hitPosition, _distance, Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPointRadius = 0.15f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPointRadius);
    }
#endif
}
