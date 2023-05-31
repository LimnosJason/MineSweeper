using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGameSettingsScript : MonoBehaviour
{
    public GameObject SettingsCanvas;
    private bool visibleCanvas=false;

    void Awake(){
        SettingsCanvas.SetActive(false);
    }

    public void ActivateSettingsCanvas(){
        if(visibleCanvas)
            visibleCanvas=false;
        else
            visibleCanvas=true;
        SettingsCanvas.SetActive(visibleCanvas);
    }
}
