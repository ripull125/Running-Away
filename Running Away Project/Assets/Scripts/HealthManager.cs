using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public GameObject DeathMenu;
    public Image healthBar;
    public float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        DeathMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            DeathMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            PauseMenu.isPaused = true;
        }
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TakeDamage(20);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Heal(5);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    public void GoToMenu()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("Main-Menu");
        PauseMenu.isPaused = false;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        {
            EditorApplication.isPlaying = false;
        }
        #else
        {
            Application.Quit();
        }
        #endif
    }
}
