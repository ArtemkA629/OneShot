using System;
using UnityEngine;

public class ScrollButtonsView : ShopView
{
    [SerializeField] private ScrollButton _leftButton;
    [SerializeField] private ScrollButton _rightButton;

    private ShopPresenter _presenter;

    private void OnEnable()
    {
        _rightButton.Clicked += OnScrollButtonClicked;
        _leftButton.Clicked += OnScrollButtonClicked;
    }

    private void OnDisable()
    {
        _rightButton.Clicked -= OnScrollButtonClicked;
        _leftButton.Clicked -= OnScrollButtonClicked;
    }

    public override void Init(ShopPresenter presenter)
    {
        _presenter = presenter;
    }

    public void DisplayActiveButtons(int currentWeaponIndex, int lastIndex)
    {
        if (currentWeaponIndex > lastIndex)
            throw new IndexOutOfRangeException("WeaponIndex can't be more than last one.");

        if (currentWeaponIndex == 0)
            ApplyButtonsDisplay(false, true);
        else if (currentWeaponIndex == lastIndex)
            ApplyButtonsDisplay(true, false);
        else
            ApplyButtonsDisplay(true, true);
    }

    private void ApplyButtonsDisplay(bool leftButtonActive, bool rightButtonActive)
    {
        _leftButton.gameObject.SetActive(leftButtonActive);
        _rightButton.gameObject.SetActive(rightButtonActive);
    }

    private void OnScrollButtonClicked(ScrollButtonType clickedButton)
    {
        _presenter.OnScroll(clickedButton);
    }
}
