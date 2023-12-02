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

    public void SetWeaponCard(Sprite weaponSprite, string cardText)
    {
        _weaponImage.sprite = weaponSprite;
        SetWeaponCardText(cardText);
    }

    public void SetWeaponCardText(string cardText)
    {
        _cardText.text = cardText;
    }

    public void SetCoinsAmount(string coinsText)
    {
        _coinsText.text = coinsText;
    }
}
