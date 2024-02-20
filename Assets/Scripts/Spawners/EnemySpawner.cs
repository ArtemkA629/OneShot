using NTC.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemySpawner : Spawner
{
    [SerializeField] private AssetReference _enemyReference;
    [SerializeField] private float _spawnRange;

    private GameObject _enemyPrefab;
    private float _timer;
    private float _spawnDelay;
    private float[] _spawnDelays = { 5f, 3f, 1f };

    private void Start()
    {
        var levelDifficulty = GlobalDataHolder.LevelDifficulty;
        _spawnDelay = _spawnDelays[(int)levelDifficulty];

        SpawnEnemy();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnDelay)
        {
            SpawnEnemy();
            _timer = 0f;
        }
    }

    private void OnDisable()
    {
        if (_enemyPrefab != null)
            Addressables.Release(_enemyPrefab);
    }

    private async void SpawnEnemy()
    {
        if (_enemyPrefab == null)
        {
            var handle = await AsyncOperationsExecutor.Load<GameObject>(_enemyReference);
            _enemyPrefab = await handle.Task;
        }

        var position = new Vector3(Random.Range(-_spawnRange, _spawnRange), 0f, Random.Range(-_spawnRange, _spawnRange));
        var rotation = _enemyPrefab.transform.rotation;

        NightPool.Spawn(_enemyPrefab, position, rotation);
    }
}
