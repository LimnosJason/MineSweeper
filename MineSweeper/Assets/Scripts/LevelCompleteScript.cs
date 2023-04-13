using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    public void RestartButton(){
        SceneManager.LoadScene("GameScene");
    }
    public void NextLevelButton(){
        //SceneManager.LoadScene("GameScene");
    }
}
