using NTC.Pool;
using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private Transform _canvasParent;
    [SerializeField] private AddingCoinView _addingCoin;

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
        var addingCoin = NightPool.Spawn<AddingCoinView>(_addingCoin, enemyPosition, Quaternion.identity, _canvasParent);
        addingCoin.Init(enemyPosition);
    }
}
