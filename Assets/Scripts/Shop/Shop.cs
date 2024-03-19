using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private WeaponItem[] _weaponItems;
    [SerializeField] private ScrollButton _rightButton;
    [SerializeField] private ScrollButton _leftButton;
    [SerializeField] private DataDeletion _dataDeletionButtonCreator;
    [SerializeField] private ShopView _view;

    private ShopController _shopController;
    private ShopModel _model;
    private SaveSystem _saveSystem;

    private void OnEnable()
    {
        _rightButton.Clicked += OnScrollButtonClicked;
        _leftButton.Clicked += OnScrollButtonClicked;
        _dataDeletionButtonCreator.ButtonClicked += OnDataDeletionButtonClicked;

        Init();
    }

    private void OnDisable()
    {
        _rightButton.Clicked -= OnScrollButtonClicked;
        _leftButton.Clicked -= OnScrollButtonClicked;
        _dataDeletionButtonCreator.ButtonClicked -= OnDataDeletionButtonClicked;
        _model.Dispose();
        _shopController.Dispose();
    }

    private void Init()
    {
        _view.Init(_leftButton, _rightButton);
        _saveSystem = new SaveSystem(_weaponItems.Length);
        var saveData = _saveSystem.Load();
        _model = new ShopModel(saveData, _view, _weaponItems);
        _shopController = new ShopController(_model, _view, _saveSystem);
    }

    public void ClickOnCard()
    {
        _shopController.OnCardClicked();
    }

    private void OnScrollButtonClicked(ScrollButtonType clickedButton)
    {
        _shopController.OnScroll(clickedButton);
    }

    private void OnDataDeletionButtonClicked()
    {
        _shopController.OnDeleteSavedData(_weaponItems);
    }
}
