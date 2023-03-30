using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] GameObject settingsCanvas;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject helpButton;

    [SerializeField] GameObject aimImage;
    
    PlayerCamera playerCamera;
    [SerializeField] GameObject playerCameraObject;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = playerCameraObject.GetComponent<PlayerCamera>();
        SetAllInactive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetAllActive(){
        settingsCanvas.SetActive(true);
        // resumeButton.SetActive(true);
        // restartButton.SetActive(true);
        // mainMenuButton.SetActive(true);
        // settingsButton.SetActive(true);
        // helpButton.SetActive(true);

        aimImage.SetActive(false);
    }
    public void SetAllInactive(){
        settingsCanvas.SetActive(false);
        // resumeButton.SetActive(false);
        // restartButton.SetActive(false);
        // mainMenuButton.SetActive(false);
        // settingsButton.SetActive(false);
        // helpButton.SetActive(false);

         aimImage.SetActive(true);
    }

    public void ResumeButton(){
        playerCamera.ResumeMethod();
    }
}
