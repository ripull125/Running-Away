using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public GameObject DeathMenu;
    public static bool isPaused;
    public float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
        DeathMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Cursor.visible = true;
            isPaused = true;
            DeathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        if (!isPaused)
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
        isPaused = false;
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
