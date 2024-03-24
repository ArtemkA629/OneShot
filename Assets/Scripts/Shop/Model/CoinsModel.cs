using System;

public class CoinsModel : ShopModel, IDisposable
{
    private readonly CoinsView _view;
    private readonly SaveData _data;
    private readonly Coins _coins = new();

    public Coins Coins => _coins;

    public CoinsModel(SaveData data, CoinsView view)
    {
        WeaponCard.Bought += OnWeaponBought;
        _coins.Changed += OnCoinsAmountChanged;
        _view = view;
        _data = data;
        _coins.SetAmount(_data.CoinsAmount + GlobalDataHolder.CoinsToAdd);
    }

    public void Dispose()
    {
        WeaponCard.Bought -= OnWeaponBought;
        _coins.Changed -= OnCoinsAmountChanged;
    }

    public override void DeleteSavedData()
    {
        _coins.SetAmount(0);
    }

    private void OnWeaponBought(int coinsToSubtract)
    {
        _coins.SetAmount(_data.CoinsAmount - coinsToSubtract);
    }

    private void OnCoinsAmountChanged()
    {
        _view.DisplayCoinsAmount(_coins.Amount.ToString());
        _data.CoinsAmount = _coins.Amount;
    }
}
