using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("WeaponItems")]
    [SerializeField] private WeaponItem[] _weaponItems;

    [Header("Buttons")]
    [SerializeField] private ScrollButton _rightButton;
    [SerializeField] private ScrollButton _leftButton;
    [SerializeField] private DataDeletionButtonCreator _dataDeletionButtonCreator;

    private WeaponCard[] _weaponCards;
    private ShopView _shopView;
    private SaveSystem _saveSystem;
    private SaveData _saveData;
    private Coins _coins = new();

    public Coins Coins => _coins;

    private void Awake()
    {
        _saveSystem = new SaveSystem(_weaponItems.Length);
        _saveData = _saveSystem.Load();

        _shopView = GetComponent<ShopView>();
        _shopView.Init(_leftButton, _rightButton);

        SetWeaponCardsData();
        GlobalDataHolder.SetCurrentWeaponModel(_weaponCards[_saveData.ChosenWeaponIndex].Model);

        _coins.SetAmount(_saveData.CoinsAmount);
    }

    private void OnEnable()
    {
        WeaponCard.Unchanged += OnWeaponCardUnchanged;
        WeaponCard.Bought += OnWeaponBought;

        _rightButton.Clicked += OnScrollButtonClick;
        _leftButton.Clicked += OnScrollButtonClick;
        _dataDeletionButtonCreator.ButtonClicked += OnDataDeletionButtonClicked;

        _coins.Changed += OnCoinsAmountChanged;
    }

    private void Start()
    {
        _coins.AddAmount(GlobalDataHolder.CoinsToAdd);
        GlobalDataHolder.ResetCoinsAmount();

        SetWeaponCardView();
        SetButtonsView();
    }

    private void OnDisable()
    {
        WeaponCard.Unchanged -= OnWeaponCardUnchanged;
        WeaponCard.Bought -= OnWeaponBought;

        _rightButton.Clicked -= OnScrollButtonClick;
        _leftButton.Clicked -= OnScrollButtonClick;
        _dataDeletionButtonCreator.ButtonClicked -= OnDataDeletionButtonClicked;

        _coins.Changed -= OnCoinsAmountChanged;

        _saveData.SetWeaponCardTexts(_weaponCards);
        _saveSystem.Save(_saveData);
    }

    public void ClickOnCard()
    {
        _weaponCards[_saveData.CurrentWeaponIndex].ChangeState(_coins.Amount);
    }

    private void SetWeaponCardsData()
    {
        _weaponCards = new WeaponCard[_weaponItems.Length];

        for (int i = 0; i < _weaponCards.Length; i++)
        {
            _weaponCards[i] = new WeaponCard(_weaponItems[i]);

            if (_saveData.WasEverSaved())
                _weaponCards[i].SetCurrentText(_saveData.WeaponCardTexts[i]);
        }
    }

    private void SetButtonsView()
    {
        _shopView.SetButtons(_saveData.CurrentWeaponIndex, _weaponCards.Length - 1);
    }

    private void SetWeaponCardView()
    {
        _shopView.SetWeaponCard(_weaponCards[_saveData.CurrentWeaponIndex].Sprite, 
            _weaponCards[_saveData.CurrentWeaponIndex].CardText);
    }

    private void OnWeaponCardUnchanged(GameObject weaponModel)
    {
        _shopView.SetWeaponCardText(_weaponCards[_saveData.CurrentWeaponIndex].CardText);
        _weaponCards[_saveData.ChosenWeaponIndex].Unchange();

        _saveData.ChosenWeaponIndex = _saveData.CurrentWeaponIndex;
    }

    private void OnWeaponBought(int coinsToSubtract)
    {
        _coins.AddAmount(-coinsToSubtract);
    }

    private void OnCoinsAmountChanged()
    {
        _shopView.SetCoinsAmount(_coins.Amount.ToString());
        _saveData.CoinsAmount = _coins.Amount;
    }

    private void OnScrollButtonClick(ScrollButtonType clickedButton)
    {
        if (clickedButton == ScrollButtonType.Right)
            _saveData.CurrentWeaponIndex++;
        else
            _saveData.CurrentWeaponIndex--;

        SetButtonsView();
        SetWeaponCardView();
    }

    private void OnDataDeletionButtonClicked()
    {
        _saveData.ResetIndexes();
        _coins.SetAmount(0);

        for (int i = 0; i < _weaponCards.Length; i++)
            _weaponCards[i].SetCurrentText(_weaponItems[i].CardTextAtStart);
    }
}