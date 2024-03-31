using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    [SerializeField] private ParticleSystem _muzzleEffect;
    [SerializeField] private int _damage;

    public ParticleSystem MuzzleEffect => _muzzleEffect;
    public int Damage => _damage;
}
