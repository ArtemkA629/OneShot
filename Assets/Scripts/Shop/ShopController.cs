using System;
using UnityEngine;

public class ShopController : IDisposable
{
    private readonly ShopModel _model;
    private readonly ShopView _view;
    private readonly SaveSystem _saveSystem;

    public ShopController(ShopModel model, ShopView view, SaveSystem saveSystem)
    {
        _model = model;
        _view = view;
        SetView(_model.Data);
        _saveSystem = saveSystem;
    }
    
    public void Dispose()
    {
        _saveSystem.Save(_model.Data);
        Debug.Log("Сохраняется");
    }

    public void OnCardClicked()
    {
        _model.ChangeCardState();
    }

    public void OnScroll(ScrollButtonType clickedButton)
    {
        _model.Scroll(clickedButton);
        SetView(_model.Data);
    }

    public void OnDeleteSavedData(WeaponItem[] weaponItems)
    {
        _model.DeleteSavedData(weaponItems);
    }

    private void SetView(SaveData saveData)
    {
        var weaponCards = _model.WeaponCards;
        int currentWeaponIndex = saveData.CurrentWeaponIndex;

        _view.Set(weaponCards, currentWeaponIndex);
    }
}
