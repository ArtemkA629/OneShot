using TMPro;
using UnityEngine;

public class CoinsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;

    public void DisplayCoinsAmount(string coinsText)
    {
        _coinsText.text = coinsText;
    }
}
