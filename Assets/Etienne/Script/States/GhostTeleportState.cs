using UnityEngine;

public class GhostTeleportState : GhostBaseState
{
    //Store furthest spawn point

    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = false;
        //Get Furthest Spawn Point from Game Manager
        manager.Ghost.Animator.SetInteger("State", 2);
    }

    public override void UpdateState(GhostStateManager manager)
    {
        //Start Coroutine Fading the Ghost
        //Once Coroutine is over, teleport the ghost to the spawn point
    }
}