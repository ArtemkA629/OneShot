public class ShopController
{
    private ShopModel _model;
    private ShopView _view;

    private SaveSystem _saveSystem;

    public ShopController(ShopModel model, ShopView view, WeaponItem[] weaponItems)
    {
        _saveSystem = new SaveSystem(weaponItems.Length);
        var saveData = _saveSystem.Load();

        _model = model;
        _model.OnEnable();
        _model.Init(saveData, view, weaponItems);

        _view = view;
        SetView(saveData);
    }
    
    public void OnDisable()
    {
        _model.OnDisable();
        _saveSystem.Save(_model.SaveData);
    }

    public void OnCardClicked()
    {
        _model.ChangeCardState();
    }

    public void OnScroll(ScrollButtonType clickedButton)
    {
        _model.Scroll(clickedButton);
        SetView(_model.SaveData);
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
