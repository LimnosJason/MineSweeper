using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerStatisticsScript : MonoBehaviour
{
    private static AudioSource coinSound;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthBarText;
    [SerializeField] TextMeshProUGUI flagText;

    PlayerEndResultScript playerEndResultScript;
    [SerializeField] GameObject playerEndResultScriptObject;

    PlaceItems placeItems;
    [SerializeField] GameObject placeItemsObject;

    GameObject randomWallBreakDetectionGameObject;

    public static int playerScore=0;
    public static int playerHealth=100;
    public static int playerflag=0;

    public static int playerExtraFlagItem;
    public static int playerExtraRandomCoinItem;
    public static int playerExtraRandomMineItem;
    public static int playerCoinCollectorItem;

    [SerializeField] TextMeshProUGUI playerExtraFlagItemText;
    [SerializeField] TextMeshProUGUI playerExtraRandomMineItemText;
    [SerializeField] TextMeshProUGUI playerExtraRandomCoinItemText;

    private static int currentMineNumber=0;
    private bool nullCoinFlag;

    void Awake(){
        currentMineNumber=0;
        playerScore=0;
        playerHealth=100;
        //playerflag=0;
        playerExtraFlagItem=PlayerPrefs.GetInt("item 1");
        playerExtraFlagItemText.text=playerExtraFlagItem.ToString();

        playerExtraRandomCoinItem=PlayerPrefs.GetInt("item 2");
        playerExtraRandomCoinItemText.text = playerExtraRandomCoinItem.ToString();

        playerExtraRandomMineItem = PlayerPrefs.GetInt("item 3");
        playerExtraRandomMineItemText.text = playerExtraRandomMineItem.ToString();

        playerExtraRandomMineItem = PlayerPrefs.GetInt("item 3");
        playerExtraRandomMineItemText.text = playerExtraRandomMineItem.ToString();

        playerCoinCollectorItem = PlayerPrefs.GetInt("item 6");

        placeItems = placeItemsObject.GetComponent<PlaceItems>();
        coinSound = gameObject.GetComponent<AudioSource>();
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
        if(Input.GetKeyDown(KeyCode.R)){
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            if(playerExtraRandomCoinItem>0){
                nullCoinFlag=false;
                do{
                    randomWallBreakDetectionGameObject=placeItems.GetRandomCoin();
                    if(randomWallBreakDetectionGameObject==null){
                        nullCoinFlag=true;
                        break;
                    }
                }while(randomWallBreakDetectionGameObject.transform.parent.gameObject.transform.Find("WallBreakDetection")==null);
                if(!nullCoinFlag){
                    randomWallBreakDetectionGameObject=randomWallBreakDetectionGameObject.transform.parent.gameObject.transform.Find("WallBreakDetection").gameObject;
                    randomWallBreakDetectionGameObject.GetComponent<WallBreakDetectionScript>().EnableCoinImage();

                    playerExtraRandomCoinItem--;
                    playerExtraRandomCoinItemText.text = playerExtraRandomCoinItem.ToString();
                    PlayerPrefs.SetInt("item 2",PlayerPrefs.GetInt("item 2")-1);
                }     
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(playerExtraRandomMineItem>0){
                if(placeItems.GetNumberOfMines()!=0){
                    SetPlayerFlag(-1);
                    playerExtraRandomMineItem--;
                    playerExtraRandomMineItemText.text = playerExtraRandomMineItem.ToString();
                    PlayerPrefs.SetInt("item 3",PlayerPrefs.GetInt("item 3")-1);

                    randomWallBreakDetectionGameObject=placeItems.GetRandomMine().transform.parent.gameObject.transform.Find("WallBreakDetection").gameObject;
                    randomWallBreakDetectionGameObject.GetComponent<WallBreakDetectionScript>().itemFlag=true;
                }
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
        else if(Input.GetKey(KeyCode.LeftControl)){
            if(playerCoinCollectorItem==1)
                placeItems.ActivateAllCoins();
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

    public void PlayCoinSound(){
        coinSound.Play(0);
    }
}
