using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 2f;  
    public Rigidbody rb;
    private bool notice = false;
    private float timeLeft;

    void Start()
    {
        timeLeft = 0.0f;
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

        //Debug.Log(Vector3.Distance(transform.position, playerTransform.position));
        Debug.Log(timeLeft);
        
        switch (state)
        {
            case EnemyState.Chase:
                moveSpeed = 13f;
                TrackPlayer();
                break;
            case EnemyState.Stalk:
                moveSpeed = 10f;
                TrackPlayer();
                break;
            case EnemyState.Wander:
                moveSpeed = 5f;
                break;
            case EnemyState.Far:
                transform.position = SpawnNearPlayer(30, 50);
                Debug.Log(Vector3.Distance(playerTransform.position,transform.position));
                break;
        }

        if (notice) {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0) {
                transform.position = SpawnNearPlayer(30, 50);
                notice = false;
                timeLeft = Random.Range(10,15);
            }
            if (Vector3.Distance(transform.position, playerTransform.position) < 1.5f) {
                transform.position = SpawnOnPlayer();
            }
        }
        if (!notice) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0) {
                transform.position = SpawnNearPlayer(10, 20);
                notice = true;
            }
        } 
    }

    EnemyState DetermineState()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance < 20) {
            if (!notice) {
                timeLeft = Random.Range(30,90);
                notice = true;                
            }
            return EnemyState.Chase;
        }
        if (distance < 60 && notice) {
            return EnemyState.Stalk;
        }
        if (distance < 60 && !notice) {
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
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.LookAt(playerTransform.position);
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    Vector3 SpawnNearPlayer(int lower, int higher)
    {
        float distance = Random.Range(lower,higher);
        return new Vector3(Random.Range(playerTransform.position.x - distance,playerTransform.position.x + distance), playerTransform.position.y, Random.Range(playerTransform.position.z - distance,playerTransform.position.z + distance));
    }

    Vector3 SpawnOnPlayer()
    {
        float distance = Random.Range(5,10);
        return new Vector3(Random.Range(playerTransform.position.x - distance,playerTransform.position.x + distance), playerTransform.position.y, Random.Range(playerTransform.position.z - distance,playerTransform.position.z + distance));
    }
}
