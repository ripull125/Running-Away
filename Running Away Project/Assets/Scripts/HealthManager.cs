using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class HealthManager : MonoBehaviour
{
    private CharController_Motor player;
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
        player = GameObject.Find("FpsController").GetComponent<CharController_Motor>();
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
        healthBar.fillAmount = player.health / 100f;
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
