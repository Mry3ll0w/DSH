using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startingPosition = transform.position;
        pathFinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    chasing = true;
                }

                else
                {
                    canSeePlayer = false;
                    chasing = false;
                }
                    
                   
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    //Para el movimiento
    public float wanderSpeed = 10f;
    public float chaseSpeed = 20f;
    public float chaseDistance = 40f;
    public float wanderDistance = 10f;
    public float mapBoundary = 100f;

    private float wanderTimer = 0f;
    public float wanderUpdateInterval = 2f;
    private UnityEngine.AI.NavMeshAgent pathFinder;

    private Transform player;
    private Vector3 startingPosition;
    private bool chasing = false;

    

    void Update()
    {
        if (!chasing)
        {
            wanderTimer += Time.deltaTime;
            if (wanderTimer >= wanderUpdateInterval)
            {
                Wander();
                wanderTimer = 0f;
            }
            FieldOfViewCheck();
        }
        else
        {
            pathFinder.SetDestination(player.position);
            pathFinder.speed = chaseSpeed;
        }
    }

    void Wander()
    {
        Vector3 playerDirection = player.position - transform.position;
        float distanceToPlayer = playerDirection.magnitude;
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * wanderDistance;

        float lerpFactor = Mathf.Clamp01(distanceToPlayer / chaseDistance);
        Vector3 targetPosition = Vector3.Lerp(startingPosition, player.position, lerpFactor);
        randomDirection += targetPosition;

        UnityEngine.AI.NavMeshHit navHit;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out navHit, wanderDistance, UnityEngine.AI.NavMesh.AllAreas))
        {
            // Asegúrese de que la posición aleatoria esté dentro de los límites del mapa y a una distancia mínima de la posición actual del enemigo
            if (Vector3.Distance(navHit.position, Vector3.zero) <= mapBoundary && Vector3.Distance(navHit.position, transform.position) > wanderDistance * 0.5f)
            {
                pathFinder.SetDestination(navHit.position);
                pathFinder.speed = wanderSpeed;
            }
        }
    }

    /*
    void LookForPlayer()
    {
        Debug.Log("Vi al jugador");
        if (Vector3.Distance(player.position, transform.position) < chaseDistance)
        {
            chasing = true;
            pathFinder.SetDestination(player.position);
            pathFinder.speed = chaseSpeed;
        }
        else
        {
            chasing = false;
        }
    }
    */
}
