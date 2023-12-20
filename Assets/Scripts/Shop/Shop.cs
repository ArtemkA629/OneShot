using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("WeaponItems")]
    [SerializeField] private WeaponItem[] _weaponItems;

    [Header("Buttons")]
    [SerializeField] private ScrollButton _rightButton;
    [SerializeField] private ScrollButton _leftButton;
    [SerializeField] private DataDeletionButtonCreator _dataDeletionButtonCreator;

    private ShopController _shopController;

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

        _shopController.OnDisable();
    }

    private void Init()
    {
        var model = new ShopModel();

        var view = GetComponent<ShopView>();
        view.Init(_leftButton, _rightButton);

        _shopController = new ShopController(model, view, _weaponItems);
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
