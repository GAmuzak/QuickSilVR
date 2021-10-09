using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAIBehaviour : MonoBehaviour
{
    [SerializeField] private string playerObjectName = "Player";
    
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask groundMask, playerMask;

    [SerializeField] private float walkRange;
    private Vector3 walkPoint;
    private bool walkPointSet;

    [SerializeField] public float attackCoolDown, attackRange;
    [SerializeField] private GameObject projectile;
    private bool alreadyAttacked;
    
    [SerializeField] private float sightRange;
    [SerializeField] private float bulletForce;
    private bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find(playerObjectName).transform;
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 directionTowardsPlayer = player.position - transform.position;
        Ray rayToPlayer = new Ray(transform.position, directionTowardsPlayer);

        if (Physics.Raycast(rayToPlayer, out RaycastHit hitInfo, 50f))
        {
            playerInSightRange = hitInfo.transform.CompareTag("Player");
        }
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);
        
        if(!(playerInSightRange && playerInAttackRange)) Patrolling();
        if(playerInSightRange && !playerInAttackRange) ChasePLayer();
        if(playerInAttackRange && playerInSightRange) AttackPlayer(); 
    }

    void Patrolling()
    {

        if (!walkPointSet)
        {
            walkPoint = SetAWalkPoint();
            Debug.Log(walkPoint);
        }
        
        if (walkPointSet)
            enemyAgent.SetDestination(walkPoint);
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 5f)
        {
            Debug.Log("Reached Destiantions");
            walkPointSet = false;
        }
            
    }

    Vector3 SetAWalkPoint()
    {
        float randomZ = Random.Range(-walkRange, walkRange);
        float randomX = Random.Range(-walkRange, walkRange);
        Vector3 walkTarget = new Vector3(transform.position.x + randomX, 0f, transform.position.z + randomZ);
        if(Physics.Raycast(new Vector3(walkTarget.x, 10f, walkTarget.z), -transform.up, groundMask)) walkPointSet = true;
        return walkTarget;
    }

    void ChasePLayer()
    {
        Debug.Log("chase");
        enemyAgent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        enemyAgent.SetDestination(transform.position);
        transform.LookAt(player);

        if (alreadyAttacked)
        {
            Debug.Log("kooldown");
            StartCoroutine(AttackCooldown());
        }

        Rigidbody bullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        bullet.AddForce((transform.forward + transform.up)* bulletForce, ForceMode.Impulse);
        alreadyAttacked = true;
        Debug.Log("attacking");
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCoolDown);
        alreadyAttacked = false;
    }
}
