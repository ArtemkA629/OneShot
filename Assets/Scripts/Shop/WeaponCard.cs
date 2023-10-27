using System;
using UnityEngine;

[Serializable]
public struct WeaponCard
{
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private string _cardText;
    [SerializeField] private int _price;

    private bool _locked;
    private bool _chosen;

    public Sprite WeaponSprite => _weaponSprite;
    public string CardText => _cardText;

    public static event Action Unchanged;

    public void ChangeState(int moneyCount)
    {
        if (_locked)
            if (_chosen)
                throw new Exception("Weaponcard can't be locked and chosen!");
            else if (moneyCount > _price)
            {
                _locked = false;
                ApplyChange("�������", false);

                return;
            }

        else if (!_chosen)
            ApplyChange("�������", false);
    }

    public void Unchange()
    {
        if (_locked)
            throw new Exception("Weaponcard can't be locked!");

        else if (_chosen)
            ApplyChange("�� �������", true);
    }

    private void ApplyChange(string text, bool chosen)
    {
        if (!chosen)
            Unchanged?.Invoke();

        _cardText = text;
        _chosen = chosen;
    }
}
