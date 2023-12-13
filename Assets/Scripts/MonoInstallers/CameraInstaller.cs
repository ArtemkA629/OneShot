using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private Camera _cameraUnit;

    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(_cameraUnit).AsSingle();
    }
}
