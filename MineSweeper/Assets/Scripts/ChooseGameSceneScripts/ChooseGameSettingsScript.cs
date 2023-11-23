using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGameSettingsScript : MonoBehaviour
{
    public GameObject SettingsCanvas;
    void Awake(){
        SettingsCanvas.SetActive(false);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            ActivateSettingsCanvas();
        }
    }

    public void ActivateSettingsCanvas(){
        SettingsCanvas.SetActive(!SettingsCanvas.activeSelf);
    }
}
