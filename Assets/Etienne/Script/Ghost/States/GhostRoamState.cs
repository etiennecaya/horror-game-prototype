using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostRoamState : GhostBaseState
{
    private int _nextPoint;

    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = false;
        manager.Ghost.Agent.updateRotation = true;
        manager.Ghost.Animator.SetInteger("State", 1);

        for (int i = 0; i < manager.Ghost.RoamPoints.Length - 1; i++)
        {
            int rnd = Random.Range(i, manager.Ghost.RoamPoints.Length);
            Transform tempGO = manager.Ghost.RoamPoints[rnd];
            manager.Ghost.RoamPoints[rnd] = manager.Ghost.RoamPoints[i];
            manager.Ghost.RoamPoints[i] = tempGO;
        }
    }

    public override void UpdateState(GhostStateManager manager)
    {
        if (manager.Ghost.Agent.remainingDistance <= manager.Ghost.Agent.stoppingDistance && manager.Ghost.Agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            GoToNextPoint(manager);
        }

        if(manager.Ghost.Target != null)
        {
            manager.SwitchState(manager.FollowState);
        }

        if (manager.Ghost.IsAttacked)
        {
            manager.SwitchState(manager.PanicState);
        }
    }

    private void GoToNextPoint(GhostStateManager manager)
    {
        if (manager.Ghost.RoamPoints.Length == 0)
        {
            return;
        }

        manager.Ghost.Agent.SetDestination(manager.Ghost.RoamPoints[_nextPoint].position);

        _nextPoint = (_nextPoint + 1) % manager.Ghost.RoamPoints.Length;
    }
}