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
    private Vector3 lastSpottedPlayerPosition;
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

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask) || Vector3.Distance(player.position, transform.position) < chaseDistance)
                {
                    canSeePlayer = true;
                    chasing = true;
                    lastSpottedPlayerPosition = player.position;
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

    private HashSet<Vector3> checkedPositions = new HashSet<Vector3>();


    void Update()
    {
        if (!chasing)
        {
            wanderTimer += Time.deltaTime;
            if (wanderTimer >= wanderUpdateInterval)
            {
                if(lastSpottedPlayerPosition.x != -999 && lastSpottedPlayerPosition.y != -999)
                {
                    pathFinder.SetDestination(lastSpottedPlayerPosition);//Cuando dejas de ver al jugador me muevo a la ultima posicion donde se le vio
                    lastSpottedPlayerPosition.x = -999;
                    lastSpottedPlayerPosition.y = -999;
                    //Vaciamos el vector de posiciones visitadas para que pueda revisitarlas
                    checkedPositions = new HashSet<Vector3>();
                }
                Wander();
                wanderTimer = 0f;
            }
            FieldOfViewCheck();
        }
        else
        {
            transform.LookAt(player);
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
            // Check if this position has already been checked before
            if (checkedPositions.Contains(navHit.position))
            {
                return;
            }

            // Add the position to the HashSet to avoid checking it again in the future
            checkedPositions.Add(navHit.position);

            // Ensure the random position is within the map boundaries and at a minimum distance from the enemy's current position
            if (Vector3.Distance(navHit.position, Vector3.zero) <= mapBoundary || Vector3.Distance(navHit.position, transform.position) > radius * 0.5f)
            {
                pathFinder.SetDestination(navHit.position);
                pathFinder.speed = wanderSpeed;
            }
        }
    }


    //Gestion de Teletransporte para fix de IA
    void OnEnable()
    {
        // Subscribe to event
        TeleportOnCollision.OnTeleport += TeleportHandler;

    }

    void OnDisable()
    {
        // Unsubscribe from event
        TeleportOnCollision.OnTeleport -= TeleportHandler;
    }

    void TeleportHandler(Vector3 v3PosicionJugador)
    {
        lastSpottedPlayerPosition = v3PosicionJugador;
        checkedPositions = new HashSet<Vector3>();
    }


}
