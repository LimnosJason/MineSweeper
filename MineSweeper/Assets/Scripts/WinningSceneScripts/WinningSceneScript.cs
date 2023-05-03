using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinningSceneScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] GameObject leftStar;
    [SerializeField] GameObject upStar;
    [SerializeField] GameObject rightStar;

    [SerializeField] GameObject leftNonStar;
    [SerializeField] GameObject upNonStar;
    [SerializeField] GameObject rightNonStar;

    private int playerScore;
    private float playerTimer;

    private int currentPlayerScore=0;
    private int currentPlayerTimer=0;
    // Start is called before the first frame update
    void Start()
    {
        playerScore=PlayerStatisticsScript.playerScore;
        playerTimer=TimerScript.timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlayerScore+5<playerScore){
            currentPlayerScore+=5;
            scoreText.text=currentPlayerScore.ToString();
        }
        else if(currentPlayerScore<playerScore){
            currentPlayerScore++;
            scoreText.text=currentPlayerScore.ToString();
        }
        else if(currentPlayerTimer<playerTimer){
            currentPlayerTimer++;
            float minutes = Mathf.FloorToInt(currentPlayerTimer / 60); 
            float seconds = Mathf.FloorToInt(currentPlayerTimer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else{
            if(currentPlayerTimer<=180 && currentPlayerTimer>120){
                leftStar.SetActive(true);
                leftNonStar.SetActive(false);
            }
            else if(currentPlayerTimer<=120 && currentPlayerTimer>60){
                leftStar.SetActive(true);
                leftNonStar.SetActive(false);
                rightStar.SetActive(true);
                rightNonStar.SetActive(false);
            }
            else if(currentPlayerTimer<=60){
                leftStar.SetActive(true);
                leftNonStar.SetActive(false);
                rightStar.SetActive(true);
                rightNonStar.SetActive(false);
                upStar.SetActive(true);
                upNonStar.SetActive(false);
            }
        }
    }

    public void RestartButton(){
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void NextLevelButton(){
        Time.timeScale = 1;
        if(PlayButtonScript.sandboxFlag==0){
            SceneManager.LoadScene("MenuScene");
        }
        else{
            PlayButtonScript.sandboxFlag++;
            MapSettingsScript.SetSettingsOfMap(PlayButtonScript.sandboxFlag);
        }
    }
    
}
