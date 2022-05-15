using UnityEngine;

public class GhostPanicState : GhostBaseState
{
    private float _panicDuration = 1f;
    private float _panicTimer;
    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = true;
        manager.Ghost.Animator.SetInteger("State", 4);
        _panicTimer = Time.time + _panicDuration;
    }

    public override void UpdateState(GhostStateManager manager)
    {
        if(Time.time > _panicTimer)
        {
            manager.SwitchState(manager.DefeatState);
        }

        if (!manager.Ghost.IsAttacked)
        {
            manager.SwitchState(manager.TeleportState);
        }
    }

}