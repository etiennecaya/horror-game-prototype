using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sentry : MonoBehaviour
{
    public int Health;
    public Transform[] PatrolPoints;

    [NonSerialized] public bool DidLastAttackHit;
    [NonSerialized] public NavMeshAgent Agent;
    [NonSerialized] public GameObject Target;
    [NonSerialized] public Animator Animator;
    private SentryStateManager _stateManager;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        _stateManager = new SentryStateManager(this);
    }

    private void Update()
    {
        _stateManager.Update();
    }
}
