using Zenject;
using UnityEngine;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private EnemySpawner _enemySpawnerUnit;

    public override void InstallBindings()
    {
        Container.Bind<EnemySpawner>().FromInstance(_enemySpawnerUnit).AsSingle();
    }
}
