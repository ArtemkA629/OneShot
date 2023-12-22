using System;

public class Health
{
    private int _amount;
    private int _maxAmount;

    public int Amount => _amount;

    public Action Changed;

    public Health(int amount)
    {
        _amount = amount;
        _maxAmount = amount;
    }

    public void AddAmount(int amountToAdd)
    {
        int currentHealth = _amount + amountToAdd;

        if (currentHealth > _maxAmount)
            throw new Exception("Invalid health amount.");

        _amount = currentHealth;
        Changed?.Invoke();
    }

    public void SubtractAmount(int amountToSubtract)
    {
        int currentHealth = _amount - amountToSubtract;

        if (currentHealth < 0)
            throw new Exception("Invalid health amount.");

        _amount = currentHealth;
        Changed?.Invoke();
    }
}
