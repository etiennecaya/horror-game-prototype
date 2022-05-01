using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GhostRoamState : GhostBaseState
{
    private float roamDistance = 5f;

    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = false;
        manager.Ghost.Agent.updateRotation = true;
        manager.Ghost.Animator.SetInteger("State", 1);
        manager.Ghost.Agent.SetDestination(GetRoamDestination(manager.Ghost.transform, roamDistance));
    }

    public override void UpdateState(GhostStateManager manager)
    {
        if (manager.Ghost.Agent.remainingDistance <= manager.Ghost.Agent.stoppingDistance && manager.Ghost.Agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            manager.Ghost.Agent.SetDestination(GetRoamDestination(manager.Ghost.transform, roamDistance));
        }

        if(manager.Ghost.Target != null)
        {
            manager.SwitchState(manager.FollowState);
        }

        if (manager.Ghost.Health <= 0)
        {
            manager.SwitchState(manager.DefeatState);
        }
    }

    private Vector3 GetRoamDestination(Transform currentTransform, float maxDistance)
    {

        Vector3 backwardPos = currentTransform.right * -maxDistance;
        Vector3 randomPos = Random.insideUnitSphere + backwardPos;

        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        while (!NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas)){ };

        return hit.position;
    }
}