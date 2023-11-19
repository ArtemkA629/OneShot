using UnityEngine;
using UnityEngine.UI;

public class CoinAddingView : MonoBehaviour
{
    [SerializeField] private float _crossFadeAlphaDuration;
    [SerializeField] private float _positionLerpSpeed;

    private Image _coinImage;
    private Vector3 _finalPosition;

    private void Start()
    {
        _coinImage = GetComponent<Image>();
    }

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

        _coinImage.CrossFadeAlpha(0, _crossFadeAlphaDuration, false);

        if (position == _finalPosition)
            Destroy(gameObject);
    }
}
