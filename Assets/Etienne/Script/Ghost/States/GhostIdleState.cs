using System.Collections;
using UnityEngine;

public class GhostIdleState : GhostBaseState
{
    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = true;
        manager.Ghost.Animator.SetInteger("State", 0);
    }

    public override void UpdateState(GhostStateManager manager)
    {

        if (manager.Ghost.IsAttacked)
        {
            manager.SwitchState(manager.PanicState);
        }
        else
        {
            manager.SwitchState(manager.RoamState);
        }
    }
}