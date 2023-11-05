using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("WeaponCard")]
    [SerializeField] private WeaponCard[] _weaponCards;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TextMeshProUGUI _cardText;

    [Header("Buttons")]
    [SerializeField] private GameObject _rightButton;
    [SerializeField] private GameObject _leftButton;

    [Header("Money")]
    [SerializeField] private TextMeshProUGUI _coinsText;

    private Coins _coins = new Coins();
    private int _currentWeaponIndex;
    private int _chosenWeaponIndex;

    public int CurrentWeaponIndex 
    {
        get { return _currentWeaponIndex; }
        set { _currentWeaponIndex = Mathf.Clamp(value, 0, _weaponCards.Length - 1); } 
    }

    private void OnEnable()
    {
        WeaponCard.Unchanged += OnWeaponCardUnchanged;
        _coins.Changed += OnCoinsAmountChanged;
    }

    private void Start()
    {
        _coins.Change(GlobalDataHolder.CoinsToAdd);
        GlobalDataHolder.ResetCoinsAmount();
    }

    private void OnDisable()
    {
        WeaponCard.Unchanged -= OnWeaponCardUnchanged;
        _coins.Changed -= OnCoinsAmountChanged;
    }

    public void Scroll(bool scrollRight)
    {
        if (scrollRight)
            CurrentWeaponIndex++;
        else
            CurrentWeaponIndex--;
        
        _weaponImage.sprite = _weaponCards[CurrentWeaponIndex].Sprite;
        _cardText.text = _weaponCards[CurrentWeaponIndex].CardText;

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

    private void OnWeaponCardUnchanged(GameObject weaponModel)
    {
        _cardText.text = _weaponCards[CurrentWeaponIndex].CardText;

        _weaponCards[_chosenWeaponIndex].Unchange();
        _chosenWeaponIndex = _currentWeaponIndex;
    }

    private void OnCoinsAmountChanged()
    {
        _coinsText.text =_coins.Amount.ToString();
    }
}
