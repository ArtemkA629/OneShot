using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CustomButton : MonoBehaviour
{
    public virtual Action Clicked { get; }

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    protected virtual void OnClick()
    {
        Clicked?.Invoke();
    }
}

[RequireComponent(typeof(Button))]
public class CustomButton<T> : CustomButton
{
    public new Action<T> Clicked;

    [SerializeField] private T _argument;

    protected override void OnClick()
    {
        Clicked?.Invoke(_argument);
    }
}
