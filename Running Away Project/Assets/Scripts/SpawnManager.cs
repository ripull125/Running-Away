using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", 300);
    }

    private void SpawnEnemy() 
    {
        Instantiate(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
