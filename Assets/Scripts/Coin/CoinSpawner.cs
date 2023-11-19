using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _canvasParent;
    [SerializeField] private CoinAddingView _addingCoin;

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
        var addingCoin = Instantiate<CoinAddingView>(_addingCoin, enemyPosition, Quaternion.identity, _canvasParent);
        addingCoin.Init(enemyPosition);
    }
}
