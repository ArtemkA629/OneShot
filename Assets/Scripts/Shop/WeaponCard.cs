using System;
using UnityEngine;

[Serializable]
public struct WeaponCard
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _model;
    [SerializeField] private string _cardText;

    private bool _locked;
    private bool _chosen;

    public Sprite Sprite => _sprite;
    public string CardText => _cardText;

    public static event Action<GameObject> Unchanged;

    public void ChangeState(int moneyCount)
    {
        if (_locked)
            if (_chosen)
                throw new Exception("Weaponcard can't be locked and chosen!");
            else if (int.TryParse(_cardText, out int result) && moneyCount > result)
            {
                _locked = false;
                ApplyChange("Выбрано", false);

                return;
            }

        else if (!_chosen)
            ApplyChange("Выбрано", false);
    }

    public void Unchange()
    {
        if (_locked)
            throw new Exception("Weaponcard can't be locked!");

        else if (_chosen)
            ApplyChange("Не выбрано", true);
    }

    private void ApplyChange(string text, bool chosen)
    {
        if (!chosen)
            Unchanged?.Invoke(_model);

        _cardText = text;
        _chosen = chosen;
    }
}
