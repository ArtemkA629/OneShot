using NTC.Pool;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _canvasParent;
    [SerializeField] private AddingCoinView _addingCoinView;

    private void OnEnable()
    {
        Enemy.CoinViewing += OnCoinViewing;
    }

    private void OnDisable()
    {
        Enemy.CoinViewing -= OnCoinViewing;
    }

    private void OnCoinViewing(Vector3 enemyPosition)
    {
        var addingCoinViewComponent = _addingCoinView.GetComponent<AddingCoinView>();
        var addingCoinView = NightPool.Spawn(addingCoinViewComponent, enemyPosition, Quaternion.identity, _canvasParent);
        addingCoinView.Init(enemyPosition);
    }
}
