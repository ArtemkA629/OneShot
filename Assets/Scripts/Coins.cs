using System;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private int _amount;

    public event Action Changed;

    public int Amount
    {
        get => _amount;
        set => _amount = Mathf.Clamp(value, 0, int.MaxValue);
    }

    public void Change(int count)
    {
        Amount += count;
        Changed?.Invoke();
    }
}
