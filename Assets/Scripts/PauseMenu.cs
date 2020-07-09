using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup pauseScreen;

    public void ContinueGame()
    {
        Utility.SetCanvasGroupEnabled(pauseScreen, false);
        Destroy(gameObject);
        Time.timeScale = 1;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ReturnToMM()
    {
        SceneManager.LoadScene("LevelMenu");
        Time.timeScale = 1;
    }


}
