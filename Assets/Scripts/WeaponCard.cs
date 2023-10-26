using System;
using UnityEngine;

[Serializable]
public struct WeaponCard
{
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private string _cardText;

    public event Action Locked = true;
    public event Action Chosen;

    public Sprite WeaponSprite => _weaponSprite;
    public string CardText => _cardText;
}
