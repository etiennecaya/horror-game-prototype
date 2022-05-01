using UnityEngine;

public class GhostFollowState : GhostBaseState
{
    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = false;
        manager.Ghost.Agent.updateRotation = true;
        manager.Ghost.Animator.SetInteger("State", 1);
    }

    public override void UpdateState(GhostStateManager manager)
    {
        Vector3 ghostPos = manager.Ghost.transform.position;
        Vector3 targetPos = Vector3.positiveInfinity;

        if(manager.Ghost.Target != null)
        {
            targetPos = manager.Ghost.Target.transform.position;
            manager.Ghost.Agent.SetDestination(targetPos);
        }

        //Exit Conditions
        if (Vector3.Distance(targetPos, ghostPos) <= manager.Ghost.AttackDistance)
        {
            manager.SwitchState(manager.AttackState);
        }

        if (manager.Ghost.Target == null)
        {
            manager.SwitchState(manager.RoamState);
        }

        if (manager.Ghost.Health <= 0)
        {
            manager.SwitchState(manager.DefeatState);
        }
    }
}