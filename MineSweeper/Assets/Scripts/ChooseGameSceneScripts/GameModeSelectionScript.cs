using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSelectionScript : MonoBehaviour
{
    public void SandBoxGameMode(){
        SceneManager.LoadScene("MenuScene");
    }
    public void CampaignGameMode(){
        SceneManager.LoadScene("PathLevel");
    }
}
