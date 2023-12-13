using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _playerUnit;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_playerUnit).AsSingle();
    }
}