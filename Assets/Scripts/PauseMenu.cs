using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup pauseScreen;
    GameController gameController;


    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
    public void ContinueGame()
    {
        Utility.SetCanvasGroupEnabled(pauseScreen, false);
        Destroy(gameObject);
        Time.timeScale = 1;
        gameController.ChangeButtonsVisibility(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        gameController.ChangeButtonsVisibility(true);
    }

    public void ReturnToMM()
    {
        SceneManager.LoadScene("LevelMenu");
        Time.timeScale = 1;
        
    }


}
