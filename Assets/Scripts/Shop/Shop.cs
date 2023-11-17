using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("WeaponCard")]
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TextMeshProUGUI _cardText;
    [SerializeField] private WeaponItem[] _weaponItems;

    [Header("Buttons")]
    [SerializeField] private GameObject _rightButton;
    [SerializeField] private GameObject _leftButton;

    [Header("Money")]
    [SerializeField] private TextMeshProUGUI _coinsText;

    private static Coins _coins = new Coins();
    private static WeaponCard[] _weaponCards;
    private static int _currentWeaponIndex;
    private static int _chosenWeaponIndex;

    public static int CurrentWeaponIndex 
    {
        get { return _currentWeaponIndex; }
        set { _currentWeaponIndex = Mathf.Clamp(value, 0, _weaponCards.Length - 1); } 
    }

    private void OnEnable()
    {
        WeaponCard.Unchanged += OnWeaponCardUnchanged;
        WeaponCard.Bought += OnWeaponBought;
        _coins.Changed += OnCoinsAmountChanged;
    }

    private void Start()
    {
        if (_weaponCards == null)
        {
            _weaponCards = new WeaponCard[_weaponItems.Length];
            for (int i = 0; i < _weaponCards.Length; i++)
                _weaponCards[i] = new WeaponCard(_weaponItems[i]);
        }

        SetWeaponCard();
        SetButtons();

        _coins.Change(GlobalDataHolder.CoinsToAdd);
        GlobalDataHolder.ResetCoinsAmount();


    }

    private void OnDisable()
    {
        WeaponCard.Unchanged -= OnWeaponCardUnchanged;
        WeaponCard.Bought -= OnWeaponBought;
        _coins.Changed -= OnCoinsAmountChanged;
    }

    public void Scroll(bool scrollRight)
    {
        if (scrollRight)
            CurrentWeaponIndex++;
        else
            CurrentWeaponIndex--;

        SetWeaponCard();

        SwitchScrollButtons(scrollRight);
    }

    public void ClickOnCard()
    {
        _weaponCards[CurrentWeaponIndex].ChangeState(_coins.Amount);
    }

    private void SwitchScrollButtons(bool scrollRight)
    {
        int firstIndex = 0;
        int secondIndex = 1;
        int lastIndex = _weaponCards.Length - 1;
        int prelastIndex = _weaponCards.Length - 2;

        bool canSwitchLeftButton = CurrentWeaponIndex == firstIndex || CurrentWeaponIndex == secondIndex;
        bool canSwitchRightButton = CurrentWeaponIndex == lastIndex || CurrentWeaponIndex == prelastIndex;

        if (canSwitchLeftButton)
            _leftButton.SetActive(scrollRight);

        if (canSwitchRightButton)
            _rightButton.SetActive(!scrollRight);
    }

    private void SetWeaponCard()
    {
        _weaponImage.sprite = _weaponCards[CurrentWeaponIndex].Sprite;
        _cardText.text = _weaponCards[CurrentWeaponIndex].CardText;
    }

    private void SetButtons()
    {
        if (CurrentWeaponIndex != 0)
            _leftButton.SetActive(true);
        else if (CurrentWeaponIndex != _weaponCards.Length - 1)
            _rightButton.SetActive(true);
    }

    private void OnWeaponCardUnchanged(GameObject weaponModel)
    {
        _cardText.text = _weaponCards[CurrentWeaponIndex].CardText;

        _weaponCards[_chosenWeaponIndex].Unchange();
        _chosenWeaponIndex = _currentWeaponIndex;
    }

    private void OnWeaponBought(int coinsToSubtract)
    {
        _coins.Change(-coinsToSubtract);
    }

    private void OnCoinsAmountChanged()
    {
        _coinsText.text =_coins.Amount.ToString();
    }
}
