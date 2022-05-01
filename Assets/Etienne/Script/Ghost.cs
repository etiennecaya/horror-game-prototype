using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public int Health;

    public NavMeshAgent Agent;
    public GameObject Target;
    public float AttackDistance;

    public Animator Animator;
    public GhostStateManager StateManager;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        StateManager = new GhostStateManager(this);

    }

    private void Update()
    {
        StateManager.Update();
    }
}
