using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public GameEndedScript gameEndedScript;
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the ExitPortal, game has ended");
            EndGame();
        }
    }

    private void EndGame()
    {
        // Show the game over banner
        gameEndedScript.ShowGameOverBanner();
        Debug.Log("Game Over! Player has reached the exit portal.");
    }
}