using UnityEngine;
using YG;

public class Shop : MonoBehaviour
{
    [SerializeField] private WeaponItem[] _weaponItems;
    [SerializeField] private DataDeletion _dataDeletion;
    [SerializeField] private WeaponCardsView _weaponCardsView;
    [SerializeField] private CoinsView _coinsView;
    [SerializeField] private ScrollButtonsView _buttonsView;

    private ShopPresenter _presenter;
    private ISaveSystem _saveSystem;
    private SaveData _saveData;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
            LoadData();
    }

    private void OnEnable()
    {
        _dataDeletion.ButtonClicked += OnDataDeletion;
        YandexGame.GetDataEvent += LoadData;
        Init();
    }

    private void OnDisable()
    {
        _dataDeletion.ButtonClicked -= OnDataDeletion;
        YandexGame.GetDataEvent -= LoadData;
        _presenter.Dispose();
        SaveData();
    }

    private void Init()
    {
        LoadData();
        var weaponCardsModel = new WeaponCardsModel(_weaponCardsView, _saveData, _weaponItems);
        var coinsModel = new CoinsModel(_coinsView, _saveData);
        var scrollButtonsModel = new ScrollButtonsModel(_buttonsView, _saveData);

        _presenter = new ShopPresenter(weaponCardsModel, coinsModel, scrollButtonsModel);
        _presenter.CoinsAmountChanged += SaveData;
        _presenter.WeaponCardChanged += SaveData;

        _weaponCardsView.Init(_presenter);
        _buttonsView.Init(_presenter);
        SaveData();
    }

    private void LoadData()
    {
        _saveSystem = new YGSaveSystem(_weaponItems.Length);
        _saveData = _saveSystem.Load();
    }

    private void SaveData()
    {
        _saveSystem.Save(_saveData);
        Debug.Log("save");
    }

    private void OnDataDeletion()
    {
        _presenter.OnDeleteSavedData(_weaponItems);
    }
}
