using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the key");
            // Change FPSController variables
            CharController_Motor controller = other.GetComponent<CharController_Motor>();

            if (GameManager.Instance != null)
            {
                Debug.Log("gameobject: " + gameObject.name);
                GameManager.Instance.CollectKey();
                Debug.Log("Key counts: " + GameManager.Instance.GetKeyCounts());
                gameObject.SetActive(false);
            }

        }
    }
}