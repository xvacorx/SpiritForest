using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public Transform patrolZoneCenter;
    public float patrolRadius = 10f;

    private Vector3 randomDestination;
    private bool isMoving;
    public float minTimeBetweenMoves = 3f;
    public float maxTimeBetweenMoves = 6f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetRandomDestination();
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {
            if (isMoving)
            {
                isMoving = false;
                animator.SetBool("IsWalking", false);  // Cambia a la animación "Idle" cuando el NPC deja de moverse
            }

            float randomWaitTime = Random.Range(minTimeBetweenMoves, maxTimeBetweenMoves);
            Invoke("SetRandomDestination", randomWaitTime);
        }
        else if (!isMoving)
        {
            isMoving = true;
            animator.SetBool("IsWalking", true);  // Cambia a la animación "Walking" cuando el NPC comienza a moverse
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += patrolZoneCenter.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, NavMesh.AllAreas);

        randomDestination = hit.position;
        navMeshAgent.SetDestination(randomDestination);
    }
}