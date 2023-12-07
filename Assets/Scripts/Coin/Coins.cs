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

    public void AddAmount(int count)
    {
        Amount += count;
        Changed?.Invoke();
    }

    public void SetAmount(int amount)
    {
        Amount = amount;
        Changed?.Invoke();
    }
}
