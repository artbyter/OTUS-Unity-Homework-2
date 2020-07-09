using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    enum Screen
    {
        None,
        Main,
        Levels,
        
    }

   

    public CanvasGroup mainScreen;
    public CanvasGroup levelsScreen;
   

    void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(levelsScreen, screen == Screen.Levels);
        
    }

    void Awake()
    {
        SetCurrentScreen(Screen.Main);
    }
        
   
    public void LoadLevel(string level)
    {
        SetCurrentScreen(Screen.None);
        LoadingScreen.instance.LoadScene(level);
        

    }

    

    public void OpenLevelMenu()
    {
        SetCurrentScreen(Screen.Levels);
        
    }

    public void OpenMainMenu()
    {
        SetCurrentScreen(Screen.Main);
    }

   

    public void ExitGame()
    {
        Application.Quit();
    }
}
