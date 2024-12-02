using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private int keysCollected = 0;
    private int keysRequired = 3;
    public GameObject door;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void CollectKey()
    {
        keysCollected++;
        if (keysCollected >= keysRequired)
        {
            Debug.Log("Found all the keys!");
            ShowDoor();
        }
    }

    public int GetKeyCounts() {
        return keysCollected;
    }

    private void ShowDoor()
    {
        if (door == null)
        {
            door = GameObject.Find("ExitPortal");
        }

        if (door == null)
        {
            door = GameObject.FindGameObjectWithTag("ExitPortal");
        }

        if (door != null)
        {
            Debug.Log("enabling the exit door");
            door.SetActive(true);
        } else
        {
            Debug.Log("door is not there");
        }
    }
}