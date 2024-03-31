using System;

public class Health
{
    private readonly int _maxAmount;

    private int _amount;

    public Health(int maxAmount)
    {
        _amount = maxAmount;
        _maxAmount = maxAmount;
    }

    public event Action Changed;

    public int Amount => _amount;

    public void SetAmount(int amount)
    {
        if (amount > _maxAmount || amount < 0)
            throw new Exception("Invalid health amount to set.");

        _amount = amount;
    }

    public void ApplyHeal(int amountToAdd)
    {
        int currentHealth = _amount + amountToAdd;

        if (currentHealth > _maxAmount)
            throw new Exception("Invalid health amount to add.");

        _amount = currentHealth;
        Changed?.Invoke();
    }

    public void ApplyDamage(int amountToSubtract)
    {
        int currentHealth = _amount - amountToSubtract;

        if (currentHealth < 0)
            throw new Exception("Invalid health amount to subtract.");

        _amount = currentHealth;
        Changed?.Invoke();
    }
}
