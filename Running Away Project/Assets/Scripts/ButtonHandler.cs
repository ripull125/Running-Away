using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_A");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
