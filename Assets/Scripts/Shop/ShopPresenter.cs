using System;

public class ShopPresenter : IDisposable
{
    private readonly WeaponCardsModel _weaponCardsModel;
    private readonly CoinsModel _coinsModel;
    private readonly ScrollButtonsModel _scrollButtonsModel;

    public event Action CoinsAmountChanged;
    public event Action WeaponCardChanged;

    public ShopPresenter(WeaponCardsModel weaponCardsModel, CoinsModel coinsModel, ScrollButtonsModel scrollButtonsModel)
    {
        _weaponCardsModel = weaponCardsModel;
        _coinsModel = coinsModel;
        _scrollButtonsModel = scrollButtonsModel;

        _coinsModel.CoinsAmountChanged += OnCoinsAmountChanged;
        _weaponCardsModel.WeaponCardChanged += OnWeaponCardChanged;

        OnInit();
    }
    
    public void Dispose()
    {
        _weaponCardsModel.Dispose();
        _coinsModel.Dispose();  
    }

    public void OnCardClicked()
    {
        _weaponCardsModel.ChangeCardState(_coinsModel.Coins.Amount);
    }

    public void OnScroll(ScrollButtonType clickedButton)
    {
        _scrollButtonsModel.ChangeIndex(clickedButton);
        _scrollButtonsModel.Scroll(_weaponCardsModel.WeaponCards);
        _weaponCardsModel.Scroll(_weaponCardsModel.WeaponCards);
    }

    public void OnDeleteSavedData(WeaponItem[] weaponItems)
    {
        _weaponCardsModel.Reset();
        _coinsModel.Reset();
    }

    private void OnInit()
    {
        _scrollButtonsModel.Scroll(_weaponCardsModel.WeaponCards);
        GlobalDataHolder.UpdateGlobalData(_weaponCardsModel.WeaponCards[_weaponCardsModel.Data.ChosenWeaponIndex].Model);
        UnityEngine.Debug.Log(_weaponCardsModel.Data.ChosenWeaponIndex);
    }

    private void OnCoinsAmountChanged()
    {
        CoinsAmountChanged?.Invoke();
    }

    private void OnWeaponCardChanged()
    {
        WeaponCardChanged?.Invoke();
    }
}
