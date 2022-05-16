using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryPatrolState : SentryBaseState
{
    private int nextPoint = 0;
    public override void EnterState(SentryStateManager manager)
    {
        manager.Sentry.Agent.isStopped = false;
        manager.Sentry.Agent.autoBraking = false;
        manager.Sentry.Animator.SetInteger("State", 1);
        manager.Sentry.MovingSound.Play();
    }

    public override void UpdateState(SentryStateManager manager)
    {
        if(!manager.Sentry.Agent.pathPending && manager.Sentry.Agent.remainingDistance < 0.5f)
        {
            GoToNextPoint(manager);
        }

        if(manager.Sentry.Target != null)
        {
            manager.Sentry.MovingSound.Stop();
            manager.SwitchState(manager.AttackState);
        }
    }

    private void GoToNextPoint(SentryStateManager manager)
    {
        if(manager.Sentry.PatrolPoints.Length == 0)
        {
            return;
        }

        manager.Sentry.Agent.SetDestination(manager.Sentry.PatrolPoints[nextPoint].position);

        nextPoint = (nextPoint + 1) % manager.Sentry.PatrolPoints.Length;
    }
}
