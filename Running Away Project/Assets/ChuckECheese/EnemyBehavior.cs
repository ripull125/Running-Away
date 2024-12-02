using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 2f;
    public Rigidbody rb;
    private float timeLeft;
    private int failSpawn;
    private float groundCheckDistance = 0.5f;

    void Start()
    {
        failSpawn = 0;
        rb = GetComponent<Rigidbody>();
        transform.position = SpawnNearPlayer(25, 45);
    }

    enum EnemyState
    {
        Chase,
        Stalk,
        Wander,
        Far
    }

    void Update()
    {
        EnemyState state = DetermineState();

        Debug.Log("" + Vector3.Distance(transform.position, playerTransform.position)+ " " + state);
        //Debug.Log(Vector3.Distance(transform.position, playerTransform.position));
        //Debug.Log(timeLeft);
        
        switch (state)
        {
            case EnemyState.Chase:
                moveSpeed = 12f;
                TrackPlayer();
                break;
            case EnemyState.Stalk:
                moveSpeed = 9f;
                TrackPlayer();
                break;
            case EnemyState.Wander:
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0) {
                    transform.position = SpawnNearPlayer(30,50);
                }
                moveSpeed = 5f;
                break;
            case EnemyState.Far:
                if (transform.position.y < -50) {
                    failSpawn ++;
                    transform.position = SpawnNearPlayer(15,20);
                } else {
                    transform.position = SpawnNearPlayer(30, 50);
                }
                state = EnemyState.Stalk;
                break;
        }

        if (IsGrounded() && Mathf.Abs(playerTransform.position.y - transform.position.y) > 10) {
            failSpawn = 0;
            moveSpeed = 14f;
            rb.velocity = new Vector3(0,7,0);
        }
    }

    EnemyState DetermineState()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance < 35) {
            return EnemyState.Chase;
        }
        if (distance < 65) {
            if (timeLeft <= 0) {
                timeLeft = Random.Range(10.0f,15.0f);
            }
            return EnemyState.Stalk;
        }
        if (distance < 140) {
            if (timeLeft <= 0) {
                timeLeft = Random.Range(10.0f,15.0f);
            }
            return EnemyState.Wander;
        }
        return EnemyState.Far;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FpsController")) {
            transform.position = SpawnOnPlayer();
            Debug.Log(transform.position);
        }
    }

    void TrackPlayer()
    {
        // Calculate direction and normalize
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        // Lock Y-axis rotation by maintaining the enemy's current height
        Vector3 lookTarget = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);

        // Rotate to look at the adjusted target
        transform.LookAt(lookTarget);

        // Move the enemy in the direction of the player
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    Vector3 SpawnNearPlayer(int lower, int higher)
    {
        float distance = Random.Range(lower,higher);
        //Debug.Log(playerTransform.position);
        rb.velocity = Vector3.zero;
        return new Vector3(
            Random.Range(playerTransform.position.x - distance,playerTransform.position.x + distance),
            playerTransform.position.y + 30 + failSpawn * 10,
            Random.Range(playerTransform.position.z - distance,playerTransform.position.z + distance)
            );
    }

    Vector3 SpawnOnPlayer()
    {
        return SpawnNearPlayer(2,5);
    }

    public bool IsGrounded()
    {
        // Raycast down without filtering layers or tags
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, groundCheckDistance))
        {
            return true;
        }
        return false;
    }
}
