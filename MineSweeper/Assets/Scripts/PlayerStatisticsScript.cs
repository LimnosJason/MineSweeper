using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerStatisticsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthBarText;
    [SerializeField] TextMeshProUGUI flagText;

    PlayerEndResultScript playerEndResultScript;
    [SerializeField] GameObject playerEndResultScriptObject;

    public static int playerScore=0;
    public static int playerHealth=100;
    public static int playerflag=0;

    private int currentMineNumber=0;

    void Awake(){

        playerScore=0;
        playerHealth=100;
        //playerflag=0;
    }

    public int GetPlayerScore(){
        return playerScore;
    }
    public int GetPlayerHealth(){
        return playerHealth;
    }
    public int GetPlayerFlag(){
        return playerflag;
    }

    public void Update(){
        scoreText.text=GetPlayerScore().ToString();
        healthBarText.text=GetPlayerHealth().ToString()+"%";
        flagText.text=GetPlayerFlag().ToString();
    }

    public void SetPlayerScore(int newScore){
        playerScore+=newScore;
    }
    public void SetPlayerHealth(int newHealth){
        playerHealth =newHealth;
        if(playerHealth<=0){
            playerHealth=0;
        }
    }
    public void SetPlayerFlag(int newFlag){
        playerflag+=newFlag;
    }
    public void StartPlayFlag(int newFlag){
        playerflag=newFlag;
    }

    public void CallPlayerWin(int change){
        currentMineNumber+=change;
        Debug.Log(currentMineNumber);
        if(currentMineNumber==0){
            playerEndResultScript = playerEndResultScriptObject.GetComponent<PlayerEndResultScript>();
            Debug.Log(playerEndResultScriptObject);
            Debug.Log("Active? "+playerEndResultScriptObject.activeInHierarchy);
            Debug.Log(playerEndResultScript);
            playerEndResultScript.PlayerWin();
        }
    }
}
