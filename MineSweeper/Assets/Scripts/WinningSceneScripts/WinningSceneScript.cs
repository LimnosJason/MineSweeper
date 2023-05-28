using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinningSceneScript : MonoBehaviour
{
    public AudioSource levelUnlockedSound;

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

    private int coinAdder;

    private int currentPlayerScore=0;
    private int currentPlayerTimer=0;
    private bool starFlag;
    private static int totalStars;
    // Start is called before the first frame update
    void Start()
    {
        totalStars=0;
        starFlag=true;
        playerScore=PlayerStatisticsScript.playerScore;
        playerTimer=TimerScript.timer;

        coinAdder=playerScore/75;

        StartCoroutine(WaitForFunction());

        if (PlayerPrefs.HasKey("coinCounter"))
            PlayerPrefs.SetInt("coinCounter",PlayerPrefs.GetInt("coinCounter")+playerScore);
        else
            PlayerPrefs.SetInt("coinCounter",playerScore);

        if(currentPlayerTimer<=180 && currentPlayerTimer>120){
            totalStars=1;
        }
        else if(currentPlayerTimer<=120 && currentPlayerTimer>60){
            totalStars=2;
        }
        else if(currentPlayerTimer<=60){
            totalStars=3;
        }
        PlayerPrefs.SetInt("level"+PlayButtonScript.sandboxFlag,totalStars);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlayerScore+coinAdder<playerScore){
            currentPlayerScore+=coinAdder;
            scoreText.text=currentPlayerScore.ToString();
        }
        else if(currentPlayerScore<playerScore){
            currentPlayerScore++;
            scoreText.text=currentPlayerScore.ToString();
        }
        if(currentPlayerTimer<playerTimer){
            currentPlayerTimer++;
            float minutes = Mathf.FloorToInt(currentPlayerTimer / 60); 
            float seconds = Mathf.FloorToInt(currentPlayerTimer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if(starFlag && currentPlayerScore>=playerScore){
            starFlag=false;  
            levelUnlockedSound.Play(0);
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
            SceneManager.LoadScene("PathLevel");
        }
    }

    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(0.1f);
        if(currentPlayerTimer<=180 && currentPlayerTimer>120){
            leftStar.SetActive(true);
            leftNonStar.SetActive(false);
        }
        else if(currentPlayerTimer<=120 && currentPlayerTimer>60){
            leftStar.SetActive(true);
            leftNonStar.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            rightStar.SetActive(true);
            rightNonStar.SetActive(false);
        }
        else if(currentPlayerTimer<=60){
            leftStar.SetActive(true);
            leftNonStar.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            rightStar.SetActive(true);
            rightNonStar.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            upStar.SetActive(true);
            upNonStar.SetActive(false);
        }
    }

}
