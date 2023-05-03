using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapSettingsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetSettingsOfMap(int mapNumber){
        if(mapNumber==1){
            PlayButtonScript.sandboxFlag=1;
            PlayButtonScript.levelSize=5;
            PlayButtonScript.levelDifficulty=10f;
        }
        else if(mapNumber==2){
            PlayButtonScript.sandboxFlag=2;
            PlayButtonScript.levelSize=7;
            PlayButtonScript.levelDifficulty=10f;
        }
        else if(mapNumber==3){
            PlayButtonScript.sandboxFlag=3;
            PlayButtonScript.levelSize=10;
            PlayButtonScript.levelDifficulty=10f;
        }
        else if(mapNumber==4){
            PlayButtonScript.sandboxFlag=4;
            PlayButtonScript.levelSize=12;
            PlayButtonScript.levelDifficulty=17.5f;
        }
        else if(mapNumber==5){
            PlayButtonScript.sandboxFlag=5;
            PlayButtonScript.levelSize=14;
            PlayButtonScript.levelDifficulty=17.5f;
        }
        else if(mapNumber==6){
            PlayButtonScript.sandboxFlag=1;
            PlayButtonScript.levelSize=16;
            PlayButtonScript.levelDifficulty=17.5f;
        }
        else if(mapNumber==7){
            PlayButtonScript.sandboxFlag=1;
            PlayButtonScript.levelSize=18;
            PlayButtonScript.levelDifficulty=25f;
        }
        else if(mapNumber==8){
            PlayButtonScript.sandboxFlag=1;
            PlayButtonScript.levelSize=20;
            PlayButtonScript.levelDifficulty=25f;
        }
        else if(mapNumber==9){
            PlayButtonScript.sandboxFlag=1;
            PlayButtonScript.levelSize=25;
            PlayButtonScript.levelDifficulty=25f;
        }

        SceneManager.LoadScene("GameScene");
    }
}
