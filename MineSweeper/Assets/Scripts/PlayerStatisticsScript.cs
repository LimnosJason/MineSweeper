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

    public static int playerExtraFlagItem;
    public static int playerExtraRandomNoMineItem;
    public static int playerExtraRandomMineItem;

    [SerializeField] TextMeshProUGUI playerExtraFlagItemText;
    [SerializeField] TextMeshProUGUI playerExtraRandomMineItemText;
    [SerializeField] TextMeshProUGUI playerExtraRandomNoMineItemText;

    private static int currentMineNumber=0;

    void Awake(){
        currentMineNumber=0;
        playerScore=0;
        playerHealth=100;
        //playerflag=0;
        playerExtraFlagItem=PlayerPrefs.GetInt("item 1");
        playerExtraFlagItemText.text=playerExtraFlagItem.ToString();

        playerExtraRandomNoMineItem=PlayerPrefs.GetInt("item 2");
        playerExtraRandomNoMineItemText.text = playerExtraRandomNoMineItem.ToString();

        playerExtraRandomMineItem = PlayerPrefs.GetInt("item 3");
        playerExtraRandomMineItemText.text = playerExtraRandomMineItem.ToString();
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

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            if(playerExtraRandomNoMineItem>0){
                playerExtraRandomNoMineItem--;
                playerExtraRandomNoMineItemText.text = playerExtraRandomNoMineItem.ToString();
                PlayerPrefs.SetInt("item 2",PlayerPrefs.GetInt("item 2")-1);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(playerExtraRandomMineItem>0){
                playerExtraRandomMineItem--;
                playerExtraRandomMineItemText.text = playerExtraRandomMineItem.ToString();
                PlayerPrefs.SetInt("item 3",PlayerPrefs.GetInt("item 3")-1);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            if(playerExtraFlagItem>0){
                playerExtraFlagItem--;
                playerExtraFlagItemText.text=playerExtraFlagItem.ToString();
                PlayerPrefs.SetInt("item 1",PlayerPrefs.GetInt("item 1")-1);

                SetPlayerFlag(1);
            }
        }

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
        if(currentMineNumber==0){
            playerEndResultScript = playerEndResultScriptObject.GetComponent<PlayerEndResultScript>();
            playerEndResultScript.PlayerWin();
        }
    }
}
