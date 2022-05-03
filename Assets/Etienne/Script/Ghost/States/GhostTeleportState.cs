using UnityEngine;

public class GhostTeleportState : GhostBaseState
{
    //Store furthest spawn point

    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = false;
        //Get Furthest Spawn Point from Game Manager
        manager.Ghost.Animator.SetInteger("State", 3);
    }

    public override void UpdateState(GhostStateManager manager)
    {
        //if Attack animation is not finished, check again next frame
        if (!manager.Ghost.Animator.GetCurrentAnimatorStateInfo(0).IsName("Teleporting") || manager.Ghost.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            return;
        }

        manager.Ghost.Agent.Warp(manager.Ghost.OriginalPosition);

        manager.SwitchState(manager.IdleState);
    }
}