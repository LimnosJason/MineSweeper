using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameScript : MonoBehaviour
{
    public GameObject quitCanvas;
    public GameObject settingsCanvas;
    void Start(){
        quitCanvas.SetActive(false);
    }
    
    public void QuitGame(){
        Application.Quit();
    }

    public void ShowQuitCanvas(){
        quitCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    public void CloseQuitCanvas(){
        quitCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
}
