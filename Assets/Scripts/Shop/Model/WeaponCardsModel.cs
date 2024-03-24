using System;

public class WeaponCardsModel : ShopModel, IDisposable
{
    private readonly WeaponCardsView _view;
    private readonly SaveData _data;

    private WeaponCard[] _weaponCards;

    public WeaponCard[] WeaponCards => _weaponCards;
    public SaveData Data => _data;

    public WeaponCardsModel(SaveData data, WeaponCardsView view, WeaponItem[] weaponItems)
    {
        WeaponCard.Unchanged += OnWeaponCardUnchanged;
        _data = data;
        _view = view;
        SetWeaponCardsData(weaponItems);
        Scroll(_weaponCards);
    }

    public void Dispose()
    {
        WeaponCard.Unchanged -= OnWeaponCardUnchanged;
        _data.SetWeaponCardTexts(_weaponCards);
    }

    public void ChangeCardState(int coinsAmount)
    {
        _weaponCards[_data.CurrentWeaponIndex].ChangeState(coinsAmount);
    }

    public override void DeleteSavedData(WeaponItem[] weaponItems)
    {
        _data.ResetIndexes();
        for (int i = 0; i < _weaponCards.Length; i++)
            _weaponCards[i].SetCurrentText(weaponItems[i].CardTextAtStart);
    }

    public override void Scroll(WeaponCard[] weaponCards)
    {
        int currentWeaponIndex = _data.CurrentWeaponIndex;
        _view.DisplayWeaponCard(weaponCards[currentWeaponIndex]);
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
        _view.DisplayWeaponCardText(_weaponCards[_data.CurrentWeaponIndex].CardText);
        _weaponCards[_data.ChosenWeaponIndex].Unchange();
        _data.ChosenWeaponIndex = _data.CurrentWeaponIndex;
    }
}