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

    public void ChangeState()
    {
        if (_locked)
            if (_chosen)
                throw new Exception("Wrong weaponcard state!");
            else
            {
                _locked = false;
                ApplyChoice();

                return;
            }

        else 
            if (!_chosen)
                ApplyChoice();
    }

    private static void UnchooseOther()
    {
        _chosen = false;
    }

    private void ApplyChoice()
    {
        UnchooseOther();
        _cardText = "Выбрано";
        _chosen = true;
    }
}
