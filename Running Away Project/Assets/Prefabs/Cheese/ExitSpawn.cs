using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] possibleSpawns = new Vector3[4];
        possibleSpawns[1] = new Vector3(9.52f, 32f, 955.3f);
        possibleSpawns[2] = new Vector3(949.56f, 27.5f, 698.72f);
        possibleSpawns[3] = new Vector3(380.62f, 34.3f, 693.13f);
        int spawnChoose = Random.Range(0,4);
        transform.position = possibleSpawns[spawnChoose];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 1.5f, 0);
    }
}
