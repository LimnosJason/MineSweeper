using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera:MonoBehaviour {
    public float speed = 150f;
    private float X;
    private float Y;
    private bool escapeFlag=false;
    public Transform playerBody;
    float xRotation = 0f;

    SettingsScript settingsScript;
    [SerializeField] GameObject settingsScriptObject;

    void Start(){
        settingsScript = settingsScriptObject.GetComponent<SettingsScript>();
    }

    void Update() {
        if(!escapeFlag){
            Cursor.lockState=CursorLockMode.Locked;
            X = Input.GetAxis("Mouse X") * speed*Time.deltaTime;
            Y = Input.GetAxis("Mouse Y") * speed*Time.deltaTime;
            xRotation -= Y;

            xRotation = Mathf.Clamp(xRotation, -90f, 45f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up*X);
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(!escapeFlag){
                Cursor.lockState=CursorLockMode.None;
                settingsScript.SetAllActive();
                Time.timeScale = 0;
                escapeFlag=true;
            }
            else{
                ResumeMethod();
            }
        }
        // }
        // else{
        //     Cursor.lockState=CursorLockMode.None;
        // }
        
    }

    public void ResumeMethod(){
        settingsScript.SetAllInactive();
        Time.timeScale = 1;
        escapeFlag=false;
        Cursor.lockState=CursorLockMode.Locked;
    }
}