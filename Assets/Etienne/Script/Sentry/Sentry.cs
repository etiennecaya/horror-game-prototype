using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sentry : MonoBehaviour
{
    public int Health;
    public Transform[] PatrolPoints;
    public Animator Animator;
    public AudioSource MovingSound;

    [NonSerialized] public bool DidLastAttackHit;
    [NonSerialized] public NavMeshAgent Agent;
    [NonSerialized] public GameObject Target;
     
    private SentryStateManager _stateManager;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        _stateManager = new SentryStateManager(this);
    }

    private void Update()
    {
        _stateManager.Update();
    }
}
