using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private WeaponItem[] _weaponItems;
    [SerializeField] private DataDeletion _dataDeletion;
    [SerializeField] private WeaponCardsView _weaponCardsView;
    [SerializeField] private CoinsView _coinsView;
    [SerializeField] private ScrollButtonsView _buttonsView;

    private ShopPresenter _presenter;
    private SaveSystem _saveSystem;
    private SaveData _saveData;

    private void OnEnable()
    {
        _dataDeletion.ButtonClicked += OnDataDeleted;
        Init();
    }

    private void OnDisable()
    {
        _dataDeletion.ButtonClicked -= OnDataDeleted;
        _presenter.Dispose();
        _saveSystem.Save(_saveData);
    }

    private void Init()
    {
        _saveSystem = new SaveSystem(_weaponItems.Length);
        _saveData = _saveSystem.Load();
        var weaponCardsModel = new WeaponCardsModel(_saveData, _weaponCardsView, _weaponItems);
        var coinsModel = new CoinsModel(_saveData, _coinsView);
        var scrollButtonsModel = new ScrollButtonsModel(_saveData, _buttonsView);
        _presenter = new ShopPresenter(weaponCardsModel, coinsModel, scrollButtonsModel);
        _weaponCardsView.Init(_presenter);
        _buttonsView.Init(_presenter);
    }

    private void OnDataDeleted()
    {
        _presenter.OnDeleteSavedData(_weaponItems);
    }
}
