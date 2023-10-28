using System;
using UnityEngine;

[Serializable]
public struct WeaponCard
{
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private string _cardText;

    private bool _locked;
    private bool _chosen;

    public Sprite WeaponSprite => _weaponSprite;
    public string CardText => _cardText;

    public static event Action<Sprite> Unchanged;

    public void ChangeState(int moneyCount)
    {
        if (_locked)
            if (_chosen)
                throw new Exception("Weaponcard can't be locked and chosen!");
            else if (int.TryParse(_cardText, out int result) && moneyCount > result)
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
            Unchanged?.Invoke(_weaponSprite);

        _cardText = text;
        _chosen = chosen;
    }
}
