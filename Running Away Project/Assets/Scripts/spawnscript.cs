using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("this is the test");
        InvokeRepeating("SpawnEnemy", 10,30);
    }

    private void SpawnEnemy()
    {
        Debug.Log("spawned");
        Instantiate(enemy, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
