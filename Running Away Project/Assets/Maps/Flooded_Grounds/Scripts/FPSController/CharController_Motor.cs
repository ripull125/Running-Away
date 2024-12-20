﻿using System.Collections;
using UnityEngine;

public class CharController_Motor : MonoBehaviour
{
	public float speed = 10.0f;
	public float jumpHeight = 2.0f;
    private float originalSpeed = 10.0f;
    private float originalJumpHeight = 2.0f;
    public bool isBoosted = false;
    public float gravity = -9.8f;
	private float yVelocity = 0.0f;

	public float health;

	private CharacterController character;
	public GameObject cam;

	float moveFB, moveLR;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;

	private bool canJump = true; // Cooldown flag
	private float jumpCooldown = 5.0f; // Cooldown duration

	void Start()
	{
		health = 100f;
		
		character = GetComponent<CharacterController>();
		speed = originalSpeed;
		jumpHeight = originalJumpHeight;

		if (Application.isEditor)
		{
			webGLRightClickRotation = false;
		}
	}

	void Update()
	{
		moveFB = Input.GetAxis("Horizontal") * speed;
		moveLR = Input.GetAxis("Vertical") * speed;

		rotX = Input.GetAxis("Mouse X") * 400;
		rotY = Input.GetAxis("Mouse Y") * 400;

		//rotX = Input.GetKey (KeyCode.Joystick1Button4);
		//rotY = Input.GetKey (KeyCode.Joystick1Button5);


		Vector3 movement = new Vector3(moveFB, gravity, moveLR);



		if (webGLRightClickRotation)
		{
			if (Input.GetKey(KeyCode.Mouse0))
			{
				CameraRotation(cam, rotX, rotY);
			}
		}
		else if (!webGLRightClickRotation)
		{
			CameraRotation(cam, rotX, rotY);
		}

		movement = transform.rotation * movement;
		character.Move(movement * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy")) {
			health -= 34;
		}
	}

	void CameraRotation(GameObject cam, float rotX, float rotY)
	{
		transform.Rotate(0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
	}

	void ResetJumpCooldown()
	{
		canJump = true; // Allow jumping again
	}

    public void BoostSpeedAndJump(float newSpeed, float newJumpHeight, int seconds)
    {
        if (!isBoosted)
        {
            StartCoroutine(ApplyBoost(newSpeed, newJumpHeight, seconds));
        }
    }

    private IEnumerator ApplyBoost(float newSpeed, float newJumpHeight, int seconds)
    {
        isBoosted = true;
        speed = newSpeed;
        jumpHeight = newJumpHeight;

        yield return new WaitForSeconds(seconds);

        speed = originalSpeed;
        jumpHeight = originalJumpHeight;
        isBoosted = false;
    }
}