using System;
using UnityEngine;

[Serializable]
public class WeaponCard
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _model;
    [SerializeField] private string _cardText;

    public Sprite Sprite => _sprite;
    public string CardText => _cardText;

    public static event Action<GameObject> Unchanged;

    public void ChangeState(int moneyCount)
    {
        if (Locked())
        {
            if (Chosen())
                throw new Exception("Weaponcard can't be locked and chosen!");
            else if (moneyCount >= int.Parse(_cardText))
            {
                ApplyChange("Выбрано");
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
