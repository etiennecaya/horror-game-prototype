using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public int Health;
    public float AttackDistance;

    [NonSerialized] public bool DidLastAttackHit;
    [NonSerialized] public Vector3 OriginalPosition;
    [NonSerialized] public NavMeshAgent Agent;
    [NonSerialized] public GameObject Target;
    [NonSerialized] public Animator Animator;
    private GhostStateManager _stateManager;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        _stateManager = new GhostStateManager(this);
        OriginalPosition = transform.position;
    }

    private void Update()
    {
        _stateManager.Update();
    }
}
