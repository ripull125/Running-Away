using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitManager : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }
}