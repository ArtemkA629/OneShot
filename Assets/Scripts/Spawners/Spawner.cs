using NTC.Pool;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void ApplyDespawn(GameObject unit)
    {
        NightPool.Despawn(unit);
    }

    public void ApplyDespawn(GameObject unit, float delay)
    {
        NightPool.Despawn(unit, delay);
    }
}
