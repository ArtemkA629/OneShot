using Zenject;
using UnityEngine;

public class CoinSpawnerInstaller : MonoInstaller
{
    [SerializeField] private CoinSpawner _coinSpawnerUnit;

    public override void InstallBindings()
    {
        Container.Bind<CoinSpawner>().FromInstance(_coinSpawnerUnit).AsSingle();
    }
}
