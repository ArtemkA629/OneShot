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

    private Coins _coins;
    private int _currentWeaponIndex;
    private int _chosenWeaponIndex;

    public int CurrentWeaponIndex 
    {
        get { return _currentWeaponIndex; }
        set { _currentWeaponIndex = Mathf.Clamp(value, 0, _weaponCards.Length - 1); } 
    }

    private void OnEnable()
    {
        WeaponCard.Unchanged += OnUnchanged;
    }

    private void OnDisable()
    {
        WeaponCard.Unchanged -= OnUnchanged;
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
        float firstIndex = 0;
        float secondIndex = 1;
        float lastIndex = _weaponCards.Length - 1;
        float prelastIndex = _weaponCards.Length - 2;

        bool canSwitchLeftButton = CurrentWeaponIndex == firstIndex || CurrentWeaponIndex == secondIndex;
        bool canSwitchRightButton = CurrentWeaponIndex == lastIndex || CurrentWeaponIndex == prelastIndex;

        if (canSwitchLeftButton)
            _leftButton.SetActive(scrollRight);

        else if (canSwitchRightButton)
            _rightButton.SetActive(!scrollRight);
    }

    private void OnUnchanged(GameObject weaponModel)
    {
        _weaponCards[_chosenWeaponIndex].Unchange();
        _chosenWeaponIndex = _currentWeaponIndex;
    }
}
