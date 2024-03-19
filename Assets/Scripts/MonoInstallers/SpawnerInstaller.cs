using Zenject;
using UnityEngine;

public class SpawnerInstaller : MonoInstaller
{
    [SerializeField] private CoinSpawner _coinSpawnerUnit;
    [SerializeField] private EnemySpawner _enemySpawnerUnit;
    [SerializeField] private WeaponModelSpawner _weaponModelSpawnerUnit;

    public override void InstallBindings()
    {
        Container.Bind<CoinSpawner>().FromInstance(_coinSpawnerUnit).AsSingle();
        Container.Bind<EnemySpawner>().FromInstance(_enemySpawnerUnit).AsSingle();
        Container.Bind<WeaponModelSpawner>().FromInstance(_weaponModelSpawnerUnit).AsSingle();
    }
}
