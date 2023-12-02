using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("WeaponItems")]
    [SerializeField] private WeaponItem[] _weaponItems;

    [Header("Buttons")]
    [SerializeField] private ScrollButton _rightButton;
    [SerializeField] private ScrollButton _leftButton;

    private int _currentWeaponIndex;
    private int _chosenWeaponIndex;
    private WeaponCard[] _weaponCards;
    private ShopView _shopView;
    private Coins _coins = new();

    public Coins Coins => _coins;
    public int CurrentWeaponIndex 
    {
        get { return _currentWeaponIndex; }
        private set { _currentWeaponIndex = Mathf.Clamp(value, 0, _weaponCards.Length - 1); } 
    }

    private void OnEnable()
    {
        WeaponCard.Unchanged += OnWeaponCardUnchanged;
        WeaponCard.Bought += OnWeaponBought;

        _rightButton.Clicked += OnScrollButtonClick;
        _leftButton.Clicked += OnScrollButtonClick;

        _coins.Changed += OnCoinsAmountChanged;
    }

    private void Awake()
    {
        _shopView = GetComponent<ShopView>();

        int coinsAmount = ShopSaving.GetInt(SavingDataConstStrings.CoinsAmount);
        _coins.SetAmount(coinsAmount);

        _currentWeaponIndex = ShopSaving.GetInt(SavingDataConstStrings.CurrentWeaponIndex);
        _chosenWeaponIndex = ShopSaving.GetInt(SavingDataConstStrings.ChosenWeaponIndex);

        if (_weaponCards == null)
            LoadWeaponCards();
        SetWeaponCardsData();
    }

    private void Start()
    {
        SetWeaponCardView();
        SetButtonsAtStart();

        _coins.Change(GlobalDataHolder.CoinsToAdd);
        GlobalDataHolder.ResetCoinsAmount();
    }

    private void OnDisable()
    {
        WeaponCard.Unchanged -= OnWeaponCardUnchanged;
        WeaponCard.Bought -= OnWeaponBought;

        _rightButton.Clicked -= OnScrollButtonClick;
        _leftButton.Clicked -= OnScrollButtonClick;

        _coins.Changed -= OnCoinsAmountChanged;
    }

    public void ClickOnCard()
    {
        _weaponCards[CurrentWeaponIndex].ChangeState(_coins.Amount);
    }

    private void SwitchScrollButtons(ScrollButtonType clickedButton)
    {
        int firstIndex = 0;
        int secondIndex = 1;
        int lastIndex = _weaponCards.Length - 1;
        int prelastIndex = _weaponCards.Length - 2;

        bool canSwitchLeftButton = CurrentWeaponIndex == firstIndex || CurrentWeaponIndex == secondIndex;
        bool canSwitchRightButton = CurrentWeaponIndex == lastIndex || CurrentWeaponIndex == prelastIndex;

        if (canSwitchRightButton)
            _rightButton.Set(clickedButton);
        if (canSwitchLeftButton)
            _leftButton.Set(clickedButton);
    }

    private void LoadWeaponCards()
    {
        _weaponCards = new WeaponCard[_weaponItems.Length];
        for (int i = 0; i < _weaponCards.Length; i++)
        {
            string key = SavingDataConstStrings.WeaponCard + i;

            _weaponCards[i] = new WeaponCard(_weaponItems[i]);
            if (ShopSaving.KeyIsNull(key))
                ShopSaving.SaveString(key, _weaponCards[i].CardText);
        }
    }

    private void SetWeaponCardsData()
    {
        for (int i = 0; i < _weaponCards.Length; i++)
        {
            string weaponCardText = ShopSaving.GetString(SavingDataConstStrings.WeaponCard + i);
            _weaponCards[i].SetCurrentText(weaponCardText);
        }
    }

    private void SetButtonsAtStart()
    {
        if (CurrentWeaponIndex != 0)
            _leftButton.Appear();
        else if (CurrentWeaponIndex != _weaponCards.Length - 1)
            _rightButton.Appear();
    }

    private void SetWeaponCardView()
    {
        _shopView.SetWeaponCard(_weaponCards[_currentWeaponIndex].Sprite, _weaponCards[_currentWeaponIndex].CardText);
    }

    private void OnWeaponCardUnchanged(GameObject weaponModel)
    {
        _shopView.SetWeaponCardText(_weaponCards[_currentWeaponIndex].CardText);
        ShopSaving.SaveString(SavingDataConstStrings.WeaponCard + CurrentWeaponIndex, _weaponCards[CurrentWeaponIndex].CardText);

        _weaponCards[_chosenWeaponIndex].Unchange();
        ShopSaving.SaveString(SavingDataConstStrings.WeaponCard + _chosenWeaponIndex, _weaponCards[_chosenWeaponIndex].CardText);

        _chosenWeaponIndex = _currentWeaponIndex;
        ShopSaving.SaveInt(SavingDataConstStrings.ChosenWeaponIndex, _chosenWeaponIndex);
    }

    private void OnWeaponBought(int coinsToSubtract)
    {
        _coins.Change(-coinsToSubtract);
    }

    private void OnCoinsAmountChanged()
    {
        _shopView.SetCoinsAmount(_coins.Amount.ToString());
        ShopSaving.SaveInt(SavingDataConstStrings.CoinsAmount, _coins.Amount);
    }

    private void OnScrollButtonClick(ScrollButtonType clickedButton)
    {
        if (clickedButton == ScrollButtonType.Right)
            _currentWeaponIndex++;
        else
            _currentWeaponIndex--;

        ShopSaving.SaveInt(SavingDataConstStrings.CurrentWeaponIndex, _currentWeaponIndex);

        SwitchScrollButtons(clickedButton);
        SetWeaponCardView();
    }
}