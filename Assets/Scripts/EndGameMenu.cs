using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class EndGameMenu : MonoBehaviour
{

    // Start is called before the first frame update


   public void SetGameText(string endText)
    {
        TextMeshProUGUI text = GetComponentsInChildren<TextMeshProUGUI>().Where(n => n.name == "EndGameText").Select(n => n).First();
        
        if (text == null)
            Debug.Log("Something wrong");
        else
            Debug.Log(text);
        text.text = endText;
    }

    public void ReturnToMM()
    {
        SceneManager.LoadScene("LevelMenu");
 
    }
}
