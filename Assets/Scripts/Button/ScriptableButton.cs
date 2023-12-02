using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ScriptableButton : MonoBehaviour
{
    private Button _button;

    protected void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}
