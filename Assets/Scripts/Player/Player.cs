using UnityEngine;

public class Player : Damageable, IAttackable
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private AttackBehaviour _attack;

    protected override void OnDead()
    {
        _gameOver.Stop();
    }

    public void Attack()
    {
        _attack.PerformAttack();
    }
}
