 using UnityEngine;
using UnityEngine.AI;

public class AnimateWalk : StateMachineBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Transform _playerTransform;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent = animator.GetComponent<NavMeshAgent>();
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;

        _navMeshAgent.enabled = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent.SetDestination(_playerTransform.position);
        var distance = Vector3.Distance(animator.transform.position, _playerTransform.position);

        if (distance < EnemyAnimatorConstants.AttackRange)
            animator.SetBool(EnemyAnimatorConstants.Attacking, true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent.enabled = false;
    }
}