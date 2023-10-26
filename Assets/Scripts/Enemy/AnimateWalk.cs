using UnityEngine;
using UnityEngine.AI;

public class AnimateWalk : StateMachineBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Transform _playerTransform;

    private float _attackRange = 1.8f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent = animator.GetComponent<NavMeshAgent>();
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent.SetDestination(_playerTransform.position);
        var distance = Vector3.Distance(animator.transform.position, _playerTransform.position);

        if (distance < _attackRange)
            animator.SetBool(EnemyAnimatorConstStrings.Attacking, true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent.SetDestination(_navMeshAgent.transform.position);
    }
}