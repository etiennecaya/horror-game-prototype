using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryAttackState : SentryBaseState
{
    public override void EnterState(SentryStateManager manager)
    {
        manager.Sentry.Agent.isStopped = true;
        manager.Sentry.Animator.SetInteger("State", 2);
        manager.Sentry.AttackSound.Play();
    }

    public override void UpdateState(SentryStateManager manager)
    {
        //if Attack animation is not finished, check again next frame
        if (!manager.Sentry.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking") || manager.Sentry.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            return;
        }
        manager.Sentry.Target = null;
        if (manager.Sentry.PatrolPoints.Length != 0)
        {
            manager.SwitchState(manager.PatrolState);
        }
        else
        {
            manager.SwitchState(manager.IdleState);
        }
    }
}
