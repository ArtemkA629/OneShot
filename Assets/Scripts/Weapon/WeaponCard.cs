using System;
using UnityEngine;

public class WeaponCard
{
    private readonly Sprite _sprite;
    private readonly WeaponModel _model;
    private readonly string _cardTextAtStart;

    private string _cardText;

    public static event Action<WeaponModel> Unchanged;
    public static event Action<int> Bought;

    public Sprite Sprite => _sprite;
    public WeaponModel Model => _model;
    public string CardTextAtStart => _cardTextAtStart;
    public string CardText => _cardText;

    public WeaponCard(WeaponItem weaponItem)
    {
        _sprite = weaponItem.Sprite;
        _model = weaponItem.Model;
        _cardTextAtStart = _cardText = weaponItem.CardTextAtStart;
    }

    public void SetCurrentText(string cardText)
    {
        if (CardTextIsAcceptable(cardText))
            _cardText = cardText;
    }

    public void ChangeState(int moneyCount)
    {
        if (Locked())
        {
            int coinsToSubtract = int.Parse(_cardText);

            if (Chosen())
                throw new Exception("Weaponcard can't be locked and chosen!");
            else if (moneyCount >= coinsToSubtract)
            {
                ApplyChange("Выбрано");
                Bought?.Invoke(coinsToSubtract);
                return;
            }
        }

        else if (!Chosen())
            ApplyChange("Выбрано");
    }

    public void Unchange()
    {
        if (Locked())
            throw new Exception("Weaponcard can't be locked!");

        else if (Chosen())
            ApplyChange("Не выбрано");
    }

    private void ApplyChange(string text)
    {
        _cardText = text;

        if (Chosen())
            Unchanged?.Invoke(_model);
    }

    private bool Locked()
    {
        return int.TryParse(_cardText, out _);
    }

    private bool Chosen()
    {
        return _cardText == "Выбрано";
    }

    private bool CardTextIsAcceptable(string cardText)
    {
        foreach (var item in UIConstantStrings.CardTextVariants)
            if (cardText == item)
                return true;
        return int.TryParse(cardText, out _);
    }
}
 