using UnityEngine;

public class Player : Damageable
{
    [SerializeField] private GameOver _gameOver;

    protected override void OnDead()
    {
        _gameOver.Stop();
    }
}
