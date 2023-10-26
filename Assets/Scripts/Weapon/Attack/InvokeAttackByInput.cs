using UnityEngine;

public class InvokeAttackByInput : MonoBehaviour
{
    private RaycastAttack _weaponAttack;

    private void Start()
    {
        _weaponAttack = GetComponent<RaycastAttack>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _weaponAttack.PerformAttack();
    }
}
