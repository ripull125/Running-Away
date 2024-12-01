using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_A");
        PauseMenu.isPaused = false;
    }

    public void QuitGame()
    { 
        Debug.Log("Quitting");
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
