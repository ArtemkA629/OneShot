using System;

public class ShopPresenter : IDisposable
{
    private readonly WeaponCardsModel _weaponCardsModel;
    private readonly CoinsModel _coinsModel;
    private readonly ScrollButtonsModel _scrollButtonsModel;

    public ShopPresenter(WeaponCardsModel weaponCardsModel, CoinsModel coinsModel, ScrollButtonsModel scrollButtonsModel)
    {
        _weaponCardsModel = weaponCardsModel;
        _coinsModel = coinsModel;
        _scrollButtonsModel = scrollButtonsModel;

        scrollButtonsModel.Scroll(_weaponCardsModel.WeaponCards);
        GlobalDataHolder.UpdateGlobalData(weaponCardsModel.WeaponCards[weaponCardsModel.Data.ChosenWeaponIndex].Model);
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
        _weaponCardsModel.DeleteSavedData(weaponItems);
        _coinsModel.DeleteSavedData();
    }
}
