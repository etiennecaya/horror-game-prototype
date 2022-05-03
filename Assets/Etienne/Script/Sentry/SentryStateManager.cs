using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryStateManager
{
    public Sentry Sentry;

    private SentryBaseState _currentState;
    public SentryIdleState IdleState = new SentryIdleState();
    public SentryPatrolState PatrolState = new SentryPatrolState();
    public SentryAttackState AttackState = new SentryAttackState();

    public SentryStateManager(Sentry sentry)
    {
        Sentry = sentry;
        SwitchState(IdleState);
    }

    public void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(SentryBaseState sentryBaseState)
    {
        _currentState = sentryBaseState;

        _currentState.EnterState(this);
    }
}
