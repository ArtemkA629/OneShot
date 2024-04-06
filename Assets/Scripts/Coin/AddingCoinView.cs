using NTC.Pool;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AddingCoinView : MonoBehaviour, IDespawnable
{
    [SerializeField] private float _crossFadeAlphaDuration;
    [SerializeField] private float _positionLerpSpeed;
    [SerializeField] private Image _coinImage;

    private Vector3 _finalPosition;

    [Inject] private readonly Camera _playerCamera;

    public void Init(Vector3 enemyPosition)
    {
        var heightIndex = 2f;
        _finalPosition = enemyPosition + Vector3.up * heightIndex;
    }

    private void Update()
    {
        var position = gameObject.transform.position;
        position = Vector3.Lerp(position, _finalPosition, Time.deltaTime * _positionLerpSpeed);
        gameObject.transform.position = position;
        _coinImage.CrossFadeAlpha(0f, _crossFadeAlphaDuration, false);
        if (position == _finalPosition)
        {
            NightPool.Despawn(this);
            OnDespawn();
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(_playerCamera.transform);
    }

    public void OnDespawn()
    {
        _coinImage.CrossFadeAlpha(1f, 0f, true);
    }
}
