using System;
using UnityEngine;

public class CustomButton : ScriptableButton
{
    public Action Clicked;

    protected override void OnClick()
    {
        Clicked?.Invoke();
    }
}

public abstract class CustomButton<T> : ScriptableButton
{
    [SerializeField] protected T _argument;

    public Action<T> Clicked;

    protected override void OnClick()
    {
        Clicked?.Invoke(_argument);
    }
}
