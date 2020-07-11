using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public  GameObject pauseMenu;
    GameObject pauseMenuObject;
    GameController gameController;
    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void ShowPauseMenu()
    {
        if(pauseMenuObject==null)
        {
            pauseMenuObject = Instantiate(pauseMenu);
            Time.timeScale = 0;
            gameController.ChangeButtonsVisibility(false);
        }
            
    }


}
