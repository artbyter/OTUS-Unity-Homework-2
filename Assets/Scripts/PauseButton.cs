using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public  GameObject pauseMenu;
    GameObject pauseMenuObject;


    public void ShowPauseMenu()
    {
        if(pauseMenuObject==null)
        {
            pauseMenuObject = Instantiate(pauseMenu);
            Time.timeScale = 0;
        }
            
    }


}
