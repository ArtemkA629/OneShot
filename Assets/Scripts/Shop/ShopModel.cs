using System;

public class ShopModel : IDisposable
{
    private readonly ShopView _view;
    private readonly SaveData _data;
    private readonly Coins _coins = new();

    private WeaponCard[] _weaponCards;

    public WeaponCard[] WeaponCards => _weaponCards;
    public Coins Coins => _coins;
    public SaveData Data => _data;

    public ShopModel(SaveData data, ShopView view, WeaponItem[] weaponItems)
    {
        WeaponCard.Unchanged += OnWeaponCardUnchanged;
        WeaponCard.Bought += OnWeaponBought;
        _coins.Changed += OnCoinsAmountChanged;

        _data = data;
        _view = view;
        Init(weaponItems);
    }

    public void Init(WeaponItem[] weaponItems)
    {
        SetWeaponCardsData(weaponItems);
        GlobalDataHolder.SetCurrentWeaponModel(_weaponCards[_data.ChosenWeaponIndex].Model);
        _coins.SetAmount(_data.CoinsAmount);
        _coins.AddAmount(GlobalDataHolder.CoinsToAdd);
        GlobalDataHolder.ResetCoinsAmount();
    }

    public void Dispose()
    {
        WeaponCard.Unchanged -= OnWeaponCardUnchanged;
        WeaponCard.Bought -= OnWeaponBought;
        _coins.Changed -= OnCoinsAmountChanged;
        _data.SetWeaponCardTexts(_weaponCards);
    }

    public void ChangeCardState()
    {
        _weaponCards[_data.CurrentWeaponIndex].ChangeState(_coins.Amount);
    }

    public void Scroll(ScrollButtonType clickedButton)
    {
        if (clickedButton == ScrollButtonType.Right)
            _data.CurrentWeaponIndex++;
        else
            _data.CurrentWeaponIndex--;
    }

    public void DeleteSavedData(WeaponItem[] weaponItems)
    {
        _data.ResetIndexes();
        _coins.SetAmount(0);

        for (int i = 0; i < _weaponCards.Length; i++)
            _weaponCards[i].SetCurrentText(weaponItems[i].CardTextAtStart);
    }

    private void SetWeaponCardsData(WeaponItem[] weaponItems)
    {
        _weaponCards = new WeaponCard[weaponItems.Length];
        bool dataWasEverSaved = _data.WasEverSaved();

        for (int i = 0; i < _weaponCards.Length; i++)
        {
            _weaponCards[i] = new WeaponCard(weaponItems[i]);
            if (dataWasEverSaved)
                _weaponCards[i].SetCurrentText(_data.WeaponCardTexts[i]);
        }
    }

    private void OnWeaponCardUnchanged(WeaponModel weaponModel)
    {
        _view.SetWeaponCardText(_weaponCards[_data.CurrentWeaponIndex].CardText);
        _weaponCards[_data.ChosenWeaponIndex].Unchange();
        _data.ChosenWeaponIndex = _data.CurrentWeaponIndex;
    }

    private void OnWeaponBought(int coinsToSubtract)
    {
        _coins.AddAmount(-coinsToSubtract);
    }

    private void OnCoinsAmountChanged()
    {
        _view.SetCoinsAmount(_coins.Amount.ToString());
        _data.CoinsAmount = _coins.Amount;
    }
}