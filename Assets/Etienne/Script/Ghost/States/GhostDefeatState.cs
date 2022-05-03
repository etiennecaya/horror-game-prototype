using UnityEngine;

public class GhostDefeatState : GhostBaseState
{

    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = true;
        manager.Ghost.Animator.SetInteger("State", 4);
        manager.Ghost.GetComponent<Collider>().enabled = false;
        manager.Ghost.Agent.enabled = false;
    }

    public override void UpdateState(GhostStateManager manager)
    {

    }
}