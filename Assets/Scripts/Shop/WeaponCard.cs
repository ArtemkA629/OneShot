using System;
using UnityEngine;

[Serializable]
public class WeaponCard
{
    private Sprite _sprite;
    private GameObject _model;
    private string _cardText;

    private static string[] _cardTextVariants =
    {
        "Выбрано",
        "Не выбрано"
    };

    public Sprite Sprite => _sprite;
    public GameObject Model => _model;
    public string CardText  => _cardText;

    public static event Action<GameObject> Unchanged;
    public static event Action<int> Bought;

    public WeaponCard(WeaponItem weaponItem)
    {
        _sprite = weaponItem.Sprite;
        _model = weaponItem.Model;
        _cardText = weaponItem.CardTextAtStart;
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
        return int.TryParse(_cardText, out int result);
    }

    private bool Chosen()
    {
        return _cardText == "Выбрано";
    }

    private bool CardTextIsAcceptable(string cardText)
    {
        foreach (var item in _cardTextVariants)
            if (cardText.Equals(item))
                return true;

        return int.TryParse(cardText, out int result);
    }
}
 