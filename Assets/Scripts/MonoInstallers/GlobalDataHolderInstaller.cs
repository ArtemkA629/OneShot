using NTC.Pool;
using UnityEngine;
using Zenject;

public class GlobalDataHolderInstaller : MonoInstaller
{
    [SerializeField] private GlobalDataHolder _globalDataHolderUnit;

    public override void InstallBindings()
    {
        DontDestroyOnLoad(Instantiate(_globalDataHolderUnit));
    }
}
