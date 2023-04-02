using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerStatisticsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthBarText;

    public static int playerScore=0;
    private int playerHealth=100;

    public int GetPlayerScore(){
        return playerScore;
    }
    public int GetPlayerHealth(){
        return playerScore;
    }

    public void Update(){
        scoreText.text=GetPlayerScore().ToString();
    }

    public void SetPlayerScore(int newScore){
        playerScore+=newScore;
        Debug.Log("ssssssssssssss"+playerScore);
        //scoreText.text=playerScore.ToString();
        //Debug.Log(scoreText.text);
    }
    public void SetPlayerHealth(int newHealth){
        playerHealth+=newHealth;
        healthBarText.text=playerHealth.ToString();
    }
}
