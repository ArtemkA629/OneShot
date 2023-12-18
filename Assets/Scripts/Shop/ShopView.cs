using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopView : MonoBehaviour
{
    [Header("WeaponCard")]
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TextMeshProUGUI _cardText;
    
    [Header("Money")]
    [SerializeField] private TextMeshProUGUI _coinsText;

    private GameObject _leftButton;
    private GameObject _rightButton;

    public void Init(ScrollButton leftButton, ScrollButton rightButton)
    {
        _leftButton = leftButton.gameObject;
        _rightButton = rightButton.gameObject;
    }

    public void SetButtons(int currentWeaponIndex, int lastIndex)
    {
        if (currentWeaponIndex > lastIndex)
            throw new IndexOutOfRangeException("WeaponIndex can't be more than last one.");

        if (currentWeaponIndex == 0)
            ApplySetButtons(false, true);
        else if (currentWeaponIndex == lastIndex)
            ApplySetButtons(true, false);
        else
            ApplySetButtons(true, true);
    }

    public void SetWeaponCard(WeaponCard weaponCard)
    {
        _weaponImage.sprite = weaponCard.Sprite;
        SetWeaponCardText(weaponCard.CardText);
    }

    public void SetWeaponCardText(string cardText)
    {
        _cardText.text = cardText;
    }

    public void SetCoinsAmount(string coinsText)
    {
        _coinsText.text = coinsText;
    }

    private void ApplySetButtons(bool leftButtonActive, bool rightButtonActive)
    {
        _leftButton.SetActive(leftButtonActive);
        _rightButton.SetActive(rightButtonActive);
    }
}
