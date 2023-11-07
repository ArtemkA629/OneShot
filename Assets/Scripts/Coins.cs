using System;
using UnityEngine;

public class Coins
{
    private int _amount;

    public event Action Changed;

    public int Amount
    {
        get => _amount;
        private set => _amount = Mathf.Clamp(value, 0, int.MaxValue);
    }

    public void Change(int count)
    {
        Amount += count;
        Debug.Log(count);
        Debug.Log(Amount);
        Changed?.Invoke();
    }
}
