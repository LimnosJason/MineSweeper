using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerStatisticsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthBarText;
    [SerializeField] TextMeshProUGUI flagText;

    public static int playerScore=0;
    public static int playerHealth=100;
    public static int playerflag=0;

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

}
