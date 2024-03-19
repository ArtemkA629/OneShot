using NTC.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _canvasParent;
    [SerializeField] private AssetReference _addingCoinViewReference;

    private GameObject _addingCoinViewPrefab;

    private void OnEnable()
    {
        Enemy.CoinViewing += OnCoinViewing;
    }

    private void OnDisable()
    {
        Enemy.CoinViewing -= OnCoinViewing;
        Addressables.Release(_addingCoinViewPrefab);
    }

    private async void OnCoinViewing(Vector3 enemyPosition)
    {
        if (_addingCoinViewPrefab == null)
        {
            var handle = await AsyncOperationsExecutor.Load<GameObject>(_addingCoinViewReference);
            _addingCoinViewPrefab = await handle.Task;
        }

        var addingCoinViewComponent = _addingCoinViewPrefab.GetComponent<AddingCoinView>();
        var addingCoinView = NightPool.Spawn(addingCoinViewComponent, enemyPosition, Quaternion.identity, _canvasParent);
        addingCoinView.Init(enemyPosition);
    }
}
