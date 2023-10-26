using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private WeaponCard[] _weaponCards;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TextMeshProUGUI _cardText;
    [SerializeField] private GameObject _rightButton;
    [SerializeField] private GameObject _leftButton;

    private int _weaponIndex;
    public int WeaponIndex 
    {
        get { return _weaponIndex; }
        set { _weaponIndex = Mathf.Clamp(value, 0, _weaponCards.Length - 1); } 
    }

    public void Scroll(bool scrollRight)
    {
        if (scrollRight)
            WeaponIndex++;
        else
            WeaponIndex--;
        
        _weaponImage.sprite = _weaponCards[WeaponIndex].WeaponSprite;
        _cardText.text = _weaponCards[WeaponIndex].CardText;

        SwitchScrollButtons(scrollRight);
    }

    public void ClickOnCard()
    {
        _weaponCards[WeaponIndex].ChangeState();
    }

    private void SwitchScrollButtons(bool scrollRight)
    {
        float firstIndex = 0;
        float secondIndex = 1;
        float lastIndex = _weaponCards.Length - 1;
        float prelastIndex = _weaponCards.Length - 2;

        if (WeaponIndex == firstIndex || WeaponIndex == secondIndex)
            _leftButton.SetActive(scrollRight);

        if (WeaponIndex == lastIndex || WeaponIndex == prelastIndex)
            _rightButton.SetActive(!scrollRight);
    }
}
