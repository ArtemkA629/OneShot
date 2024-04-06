public abstract class AttackBehaviour
{
    private readonly int _damage;

    protected int Damage => _damage;

    public AttackBehaviour(int damage)
    {
        _damage = damage;
    }

    public abstract void PerformAttack();
}
