using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Damageable _enemy;
    [SerializeField] private float _spawnRange;
    [SerializeField] private float _spawnDelay;

    private float _timer = 0f;

    public static float[] _spawnDelays = { 5f, 3f, 1.5f };

    private void Start()
    {
        _spawnDelay = _spawnDelays[(int)LevelDataHolder.LevelDifficulty];

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

    private void SpawnEnemy()
    {
        var position = new Vector3(Random.Range(-_spawnRange, _spawnRange), 0f, Random.Range(-_spawnRange, _spawnRange));
        var rotation = _enemy.transform.rotation;

        Instantiate(_enemy, position, rotation);
    }
}
