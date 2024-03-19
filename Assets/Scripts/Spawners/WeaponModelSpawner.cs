using UnityEngine;
using Zenject;

public class WeaponModelSpawner : MonoBehaviour
{
    [Inject] private readonly Player _player;

    [SerializeField] private Transform _parent;

    private void Awake()
    {
        _player.SetModel(Instantiate(GlobalDataHolder.WeaponModel, _parent, false));
    }
}