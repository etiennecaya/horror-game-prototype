using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryAttackState : SentryBaseState
{
    public override void EnterState(SentryStateManager manager)
    {
        manager.Sentry.Animator.SetInteger("State", 2);
    }

    public override void UpdateState(SentryStateManager manager)
    {
        throw new System.NotImplementedException();
    }
}
