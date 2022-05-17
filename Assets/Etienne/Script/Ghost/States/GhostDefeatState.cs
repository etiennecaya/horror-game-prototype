using UnityEngine;

public class GhostDefeatState : GhostBaseState
{

    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = true;
        manager.Ghost.Animator.SetInteger("State", 5);
        manager.Ghost.GhostDetectionPrefab.transform.localScale = new Vector3(0f,0f,0f);
        manager.Ghost.Agent.enabled = false;
        manager.Ghost.DeathSound.Play();
    }

    public override void UpdateState(GhostStateManager manager)
    {

    }
}