using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void FreezeAndRemoveAim(){
        aimImage.SetActive(false);
        // Time.timeScale = 0;
    }
    public void SetAllActive(){
        settingsCanvas.SetActive(true);
        aimImage.SetActive(false);
    }
    public void SetAllInactive(){
        settingsCanvas.SetActive(false);
         aimImage.SetActive(true);
    }

    public void ResumeButton(){
        playerCamera.ResumeMethod();
    }

    public void RestartButton(){
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButton(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
