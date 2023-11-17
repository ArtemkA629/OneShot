using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    [SerializeField] private ParticleSystem _muzzleEffect;
    public ParticleSystem MuzzleEffect => _muzzleEffect;
}
