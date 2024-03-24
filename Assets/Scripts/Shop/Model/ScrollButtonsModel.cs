public class ScrollButtonsModel : ShopModel
{
    private readonly SaveData _data;
    private readonly ScrollButtonsView _view;

    public ScrollButtonsModel(SaveData data, ScrollButtonsView view)
    {
        _data = data;
        _view = view;
    }

    public void ChangeIndex(ScrollButtonType clickedButton)
    {
        if (clickedButton == ScrollButtonType.Right)
            _data.CurrentWeaponIndex++;
        else
            _data.CurrentWeaponIndex--;
    }

    public override void Scroll(WeaponCard[] weaponCards)
    {
        int currentWeaponIndex = _data.CurrentWeaponIndex;
        _view.DisplayActiveButtons(currentWeaponIndex, weaponCards.Length - 1);
    }
}
