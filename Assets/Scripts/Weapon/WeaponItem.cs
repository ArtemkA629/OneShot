using UnityEngine;

[CreateAssetMenu(fileName = "WeaponItem", menuName = "ScriptableObject/WeaponItem")]
public class WeaponItem : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private WeaponModel _model;
    [SerializeField] private string _cardTextAtStart;

    public Sprite Sprite => _sprite;
    public WeaponModel Model => _model;
    public string CardTextAtStart => _cardTextAtStart;
}
