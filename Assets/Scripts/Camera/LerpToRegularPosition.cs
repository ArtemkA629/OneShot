using UnityEngine;

public class LerpToRegularPosition : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _positionLerpSpeed = 8f;

    private Transform _cashedTransform;
    private Vector3 _regularCameraLocalPosition;

    private void Awake()
    {
        _cashedTransform = transform;
        _regularCameraLocalPosition = _cashedTransform.localPosition;
    }

    private void LateUpdate()
    {
        var position = _cashedTransform.localPosition;

        position = Vector3.Lerp(position, _regularCameraLocalPosition, Time.deltaTime * _positionLerpSpeed);

        _cashedTransform.localPosition = position;
    }
}
