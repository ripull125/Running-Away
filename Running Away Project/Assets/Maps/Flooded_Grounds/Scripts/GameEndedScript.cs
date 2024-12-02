using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndedScript : MonoBehaviour
{
    private void Start()
    {
        // Ensure the banner is hidden at the start
        gameObject.SetActive(false);
    }

    public void ShowGameOverBanner()
    {
        gameObject.SetActive(true);
    }

}