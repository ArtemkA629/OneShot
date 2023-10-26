using System.Collections;
using UnityEngine;

public class WeaponAiming : MonoBehaviour
{
    private Animator _animator;
    private Camera _camera;
    private Coroutine _zoomCoroutine;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _camera = GetComponentInParent<Camera>();
    }

    public void AnimateAiming(bool aiming, float changedFieldOfView, float duration)
    {
        _animator.SetBool(WeaponAnimatorConstStrings.Aiming, aiming);

        ManageFieldOfViewChanging(changedFieldOfView, duration);
    }

    IEnumerator ChangeFieldOfView(Camera camera, float changedFieldOfView, float duration)
    {
        float counter = 0;
        float initialFieldOfView = camera.fieldOfView;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            float viewTime = counter / duration;
            camera.fieldOfView = Mathf.Lerp(initialFieldOfView, changedFieldOfView, viewTime);

            yield return null;
        }
    }

    private void ManageFieldOfViewChanging(float changedFieldOfView, float duration)
    {
        if (_zoomCoroutine != null)
            StopCoroutine(_zoomCoroutine);

        _zoomCoroutine = StartCoroutine(ChangeFieldOfView(_camera, changedFieldOfView, duration));
    }
}
