using System.Collections;
using UnityEngine;

public class GhostIdleState : GhostBaseState
{
    private float _delayAmount = 2.5f;
    private float _delayTime;
    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = true;
        manager.Ghost.Animator.SetInteger("State", 0);
        _delayTime = Time.time + _delayAmount;
    }

    public override void UpdateState(GhostStateManager manager)
    {
        if(Time.time < _delayTime)
        {
            return;
        }

        if (manager.Ghost.Health <= 0)
        {
            manager.SwitchState(manager.DefeatState);
        }
        else
        {
            manager.SwitchState(manager.RoamState);
        }
    }
}