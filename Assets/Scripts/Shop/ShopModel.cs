using UnityEngine;

public class ShopModel
{
    private ShopView _shopView;

    private WeaponCard[] _weaponCards;
    private Coins _coins = new();
    private SaveData _saveData;

    public WeaponCard[] WeaponCards => _weaponCards;
    public Coins Coins => _coins;
    public SaveData SaveData => _saveData;

    public void Init(SaveData saveData, ShopView shopView, WeaponItem[] weaponItems)
    {
        _saveData = saveData;
        _shopView = shopView;

        SetWeaponCardsData(weaponItems);
        GlobalDataHolder.SetCurrentWeaponModel(_weaponCards[_saveData.ChosenWeaponIndex].Model);

        _coins.SetAmount(_saveData.CoinsAmount);
        _coins.AddAmount(GlobalDataHolder.CoinsToAdd);
        GlobalDataHolder.ResetCoinsAmount();
    }

    public void OnEnable()
    {
        WeaponCard.Unchanged += OnWeaponCardUnchanged;
        WeaponCard.Bought += OnWeaponBought;

        _coins.Changed += OnCoinsAmountChanged;
    }

    public void OnDisable()
    {
        WeaponCard.Unchanged -= OnWeaponCardUnchanged;
        WeaponCard.Bought -= OnWeaponBought;

        _coins.Changed -= OnCoinsAmountChanged;

        _saveData.SetWeaponCardTexts(_weaponCards);
    }

    public void ChangeCardState()
    {
        _weaponCards[_saveData.CurrentWeaponIndex].ChangeState(_coins.Amount);
    }

    public void Scroll(ScrollButtonType clickedButton)
    {
        if (clickedButton == ScrollButtonType.Right)
            _saveData.CurrentWeaponIndex++;
        else
            _saveData.CurrentWeaponIndex--;
    }

    public void DeleteSavedData(WeaponItem[] weaponItems)
    {
        _saveData.ResetIndexes();
        _coins.SetAmount(0);

        for (int i = 0; i < _weaponCards.Length; i++)
            _weaponCards[i].SetCurrentText(weaponItems[i].CardTextAtStart);
    }

    private void SetWeaponCardsData(WeaponItem[] weaponItems)
    {
        _weaponCards = new WeaponCard[weaponItems.Length];
        bool savingDataWasEverSaved = _saveData.WasEverSaved();

        for (int i = 0; i < _weaponCards.Length; i++)
        {
            _weaponCards[i] = new WeaponCard(weaponItems[i]);

            if (savingDataWasEverSaved)
                _weaponCards[i].SetCurrentText(_saveData.WeaponCardTexts[i]);
        }
    }

    private void OnWeaponCardUnchanged(GameObject weaponModel)
    {
        _shopView.SetWeaponCardText(_weaponCards[_saveData.CurrentWeaponIndex].CardText);
        _weaponCards[_saveData.ChosenWeaponIndex].Unchange();

        _saveData.ChosenWeaponIndex = _saveData.CurrentWeaponIndex;
    }

    private void OnWeaponBought(int coinsToSubtract)
    {
        _coins.AddAmount(-coinsToSubtract);
    }

    private void OnCoinsAmountChanged()
    {
        _shopView.SetCoinsAmount(_coins.Amount.ToString());
        _saveData.CoinsAmount = _coins.Amount;
    }
}