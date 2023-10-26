using DG.Tweening;
using UnityEngine;

public class ShakeCameraOnWeaponAttack : MonoBehaviour, IWeaponAttackReaction
{
    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    public void ReactOnAttack()
    {
        _cameraTransform
            .DOShakePosition(0.15f, 1f, 10, 90f, false, true, ShakeRandomnessMode.Harmonic)
            .SetEase(Ease.InOutBounce);

        _cameraTransform
            .DOShakeRotation(0.15f, 1f, 10, 90f, true, ShakeRandomnessMode.Harmonic)
            .SetEase(Ease.InOutBounce);
    }
}
