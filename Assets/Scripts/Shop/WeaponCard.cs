using System;
using UnityEngine;

[Serializable]
public class WeaponCard
{
    private Sprite _sprite;
    private GameObject _model;
    private string _cardText;

    public Sprite Sprite => _sprite;
    public string CardText => _cardText;

    public static event Action<GameObject> Unchanged;
    public static event Action<int> Bought;

    public WeaponCard() { }

    public WeaponCard(WeaponItem weaponItem)
    {
        _sprite = weaponItem.Sprite;
        _model = weaponItem.Model;
        _cardText = weaponItem.CardTextAtStart;
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
        {
            ApplyChange("Выбрано");
            Debug.Log("edf");
        }
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
}
