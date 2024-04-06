using NTC.Pool;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private readonly float[] _spawnDelays = { 5f, 3f, 1f };

    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnRange;

    private float _spawnDelay;

    private void Start()
    {
        var levelDifficulty = GlobalDataHolder.LevelDifficulty;
        _spawnDelay = _spawnDelays[(int)levelDifficulty];
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            var position = new Vector3(Random.Range(-_spawnRange, _spawnRange), 0f, Random.Range(-_spawnRange, _spawnRange));
            var rotation = _enemy.transform.rotation;
            NightPool.Spawn(_enemy, position, rotation);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
