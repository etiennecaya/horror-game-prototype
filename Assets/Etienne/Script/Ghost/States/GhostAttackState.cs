using System.Collections;
using UnityEngine;
public class GhostAttackState : GhostBaseState
{
    private float _rotationSpeed = 20f;
    public override void EnterState(GhostStateManager manager)
    {
        manager.Ghost.Agent.isStopped = true;
        manager.Ghost.Agent.updateRotation = false;
        manager.Ghost.Animator.SetInteger("State", 2);
        manager.Ghost.AttackSound.Play();
    }

    public override void UpdateState(GhostStateManager manager)
    {

        Vector3 ghostPos = manager.Ghost.transform.position;
        Vector3 targetPos = Vector3.positiveInfinity;

        if (manager.Ghost.Target != null)
        {
            targetPos = manager.Ghost.Target.transform.position;
            Vector3 lookPos = targetPos - ghostPos;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            manager.Ghost.transform.rotation = Quaternion.Slerp(manager.Ghost.transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }


        //if Attack animation is not finished, check again next frame
        if (!manager.Ghost.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking") || manager.Ghost.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            return;
        }

        //if Player is still visible
        if (manager.Ghost.Target != null)
        {
            if(manager.Ghost.DidLastAttackHit)
            {
                manager.Ghost.DidLastAttackHit = false;
                manager.SwitchState(manager.TeleportState);
            }
            else if(Vector3.Distance(targetPos, ghostPos) > manager.Ghost.AttackDistance)
            {
                manager.SwitchState(manager.FollowState);
            }
            else
            {
                manager.Ghost.Animator.Play("Attacking");
                manager.Ghost.AttackSound.Play();
            }
        }
        else
        {
            manager.SwitchState(manager.RoamState);
        }
    }
}