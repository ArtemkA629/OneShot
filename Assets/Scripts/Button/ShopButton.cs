using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    public void OnClick()
    {
        _menu.SetActive(false);
        YGAdsProvider.TryShowFullScreenAdWithChance();
    }
}
