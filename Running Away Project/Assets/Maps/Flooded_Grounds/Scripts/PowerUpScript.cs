using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    public float newSpeed = 20f; // new speed for the FpsController
    public float newJumpHeight = 4f; // new speed for the FpsController
    public int applySeconds = 3; // for how many seconds this boost lasts
    public Vector3[] randomPositions; // Possible positions 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the powerup");
            // Change FPSController variables
            CharController_Motor controller = other.GetComponent<CharController_Motor>();
            if (controller != null)
            {
                controller.BoostSpeedAndJump(newSpeed, newJumpHeight, applySeconds);
            }

            // Move PowerUp to a random position
            //int randomIndex = Random.Range(0, randomPositions.Length);
            //transform.position = randomPositions[randomIndex];
        }
    }
}