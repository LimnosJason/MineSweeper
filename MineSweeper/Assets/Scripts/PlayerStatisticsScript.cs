using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerStatisticsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthBarText;

    private int playerScore=0;
    private int playerHealth=100;

    public int GetPlayerScore(){
        return playerScore;
    }
    public int GetPlayerHealth(){
        return playerScore;
    }

    public void SetPlayerScore(int newScore){
        playerScore+=newScore;
        scoreText.text=playerScore.ToString();
        Debug.Log(scoreText.text);
    }
    public void SetPlayerHealth(int newHealth){
        playerHealth+=newHealth;
        healthBarText.text=playerHealth.ToString();
    }
}
