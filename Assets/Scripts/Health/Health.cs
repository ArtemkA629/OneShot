using System;

public class Health
{
    private int _amount;
    private int _maxAmount;

    public int Amount => _amount;

    public event Action Changed;

    public Health(int maxAmount)
    {
        _amount = maxAmount;
        _maxAmount = maxAmount;
    }

    public void SetAmount(int amount)
    {
        if (amount > _maxAmount || amount < 0)
            throw new Exception("Invalid health amount to set.");

        _amount = amount;
    }

    public void AddAmount(int amountToAdd)
    {
        int currentHealth = _amount + amountToAdd;

        if (currentHealth > _maxAmount)
            throw new Exception("Invalid health amount to add.");

        _amount = currentHealth;
        Changed?.Invoke();
    }

    public void SubtractAmount(int amountToSubtract)
    {
        int currentHealth = _amount - amountToSubtract;

        if (currentHealth < 0)
            throw new Exception("Invalid health amount to subtract.");

        _amount = currentHealth;
        Changed?.Invoke();
    }
}
