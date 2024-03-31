using System.Collections;
using UnityEngine;

public class WeaponAiming : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Camera _camera;
    private Coroutine _zoomCoroutine;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void Animate(bool aiming, float changedFieldOfView, float duration)
    {
        _animator.SetBool(WeaponAnimatorConstStrings.Aiming, aiming);
        ManageFieldOfViewChanging(changedFieldOfView, duration);
    }

    private IEnumerator ChangeFieldOfView(float changedFieldOfView, float duration)
    {
        float counter = 0;
        float initialFieldOfView = _camera.fieldOfView;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float viewTime = counter / duration;
            _camera.fieldOfView = Mathf.Lerp(initialFieldOfView, changedFieldOfView, viewTime);
            yield return null;
        }
    }

    private void ManageFieldOfViewChanging(float changedFieldOfView, float duration)
    {
        if (_zoomCoroutine != null)
            StopCoroutine(_zoomCoroutine);
        _zoomCoroutine = StartCoroutine(ChangeFieldOfView(changedFieldOfView, duration));
    }
}
