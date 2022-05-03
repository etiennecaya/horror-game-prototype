using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryIdleState : SentryBaseState
{
    private float _delayAmount = 2.5f;
    private float _delayTime;
    public override void EnterState(SentryStateManager manager)
    {
        manager.Sentry.Agent.isStopped = true;
        manager.Sentry.Animator.SetInteger("State", 0);
        _delayTime = Time.time + _delayAmount;
    }

    public override void UpdateState(SentryStateManager manager)
    {
        if (Time.time < _delayTime)
        {
            return;
        }

        manager.SwitchState(manager.PatrolState);
    }
}
