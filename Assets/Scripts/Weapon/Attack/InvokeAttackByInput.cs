using UnityEngine;

public class InvokeAttackByInput : MonoBehaviour
{
    private IAttackable _attackable;

    private void Start()
    {
        _attackable = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _attackable.Attack();
    }
}
