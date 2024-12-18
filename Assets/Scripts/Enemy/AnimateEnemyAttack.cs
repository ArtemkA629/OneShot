using UnityEngine;

public class AnimateEnemyAttack : StateMachineBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private Transform _playerTransform;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerTransform = FindObjectOfType<Player>().transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(_playerTransform);
        var distance = Vector3.Distance(animator.transform.position, _playerTransform.position);
        if (distance > _enemyPrefab.AttackRange)
            animator.SetBool(EnemyAnimatorConstStrings.Attacking, false);
    }
}
