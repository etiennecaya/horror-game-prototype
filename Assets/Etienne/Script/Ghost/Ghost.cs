using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public int Health;
    public float AttackDistance;
    public Animator Animator;
    public GameObject GhostDetectionPrefab;
    public Transform[] RoamPoints;
    public AudioSource AttackSound;
    public AudioSource DeathSound;

    [NonSerialized] public bool DidLastAttackHit;
    [NonSerialized] public bool IsAttacked;
    [NonSerialized] public Vector3 OriginalPosition;
    [NonSerialized] public NavMeshAgent Agent;
    [NonSerialized] public GameObject Target;
    private GhostStateManager _stateManager;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        _stateManager = new GhostStateManager(this);
        OriginalPosition = transform.position;
    }

    private void Update()
    {
        _stateManager.Update();
    }
}
