using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponCardsView : ShopView
{
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TextMeshProUGUI _cardText;

    private ShopPresenter _presenter;

    public override void Init(ShopPresenter shopPresenter)
    {
        _presenter = shopPresenter;
    }

    public void DisplayWeaponCard(WeaponCard weaponCard)
    {
        _weaponImage.sprite = weaponCard.Sprite;
        DisplayWeaponCardText(weaponCard.CardText);
    }

    public void DisplayWeaponCardText(string cardText)
    {
        _cardText.text = cardText;
    }

    public void ClickOnCard()
    {
        _presenter.OnCardClicked();
    }
}
