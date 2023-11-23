using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToChooseGameModeScene : MonoBehaviour
{
    public void ChooseGameMode(){
        SceneManager.LoadScene("ChooseGame");
    }
}
