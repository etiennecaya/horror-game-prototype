using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStateManager
{
    public Ghost Ghost;

    private GhostBaseState _currentState;
    public GhostIdleState IdleState = new GhostIdleState();
    public GhostRoamState RoamState = new GhostRoamState();
    public GhostFollowState FollowState = new GhostFollowState();
    public GhostPanicState PanicState = new GhostPanicState();
    public GhostAttackState AttackState = new GhostAttackState();
    public GhostTeleportState TeleportState = new GhostTeleportState();
    public GhostDefeatState DefeatState = new GhostDefeatState();

    public GhostStateManager(Ghost ghost)
    {
        Ghost = ghost;
        SwitchState(IdleState);
    }

    public void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(GhostBaseState ghostBaseState)
    {
        _currentState = ghostBaseState;

        _currentState.EnterState(this);
    }
}
