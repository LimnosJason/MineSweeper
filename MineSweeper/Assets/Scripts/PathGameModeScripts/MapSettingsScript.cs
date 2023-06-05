using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MapSettingsScript : MonoBehaviour
{

    [SerializeField] Sprite emptyStar;
    [SerializeField] Sprite filledStar;

    public static GameObject currentButton;
    public static GameObject nextButton;

    GameObject lockImage;
    SpriteRenderer pathLeftStar;
    SpriteRenderer pathMiddleStar;
    SpriteRenderer pathRightStar;

    // Start is called before the first frame update
    void Start()
    {
        int i;
        int totalStars=0;
        for(i=1;i<10;i++){
            if (PlayerPrefs.HasKey("level"+i)){
                totalStars=PlayerPrefs.GetInt("level"+i);
                currentButton = GameObject.Find("Button "+i);

                if(i!=9){
                    nextButton = GameObject.Find("Button "+(i+1));
                    lockImage=nextButton.transform.Find("Lock").gameObject;
                    if(lockImage.activeSelf){
                        lockImage.SetActive(false);
                    }
                }
                if(totalStars==3){ 
                    currentButton.transform.Find("Image").gameObject.GetComponent<Image>().sprite=filledStar;                   
                    currentButton.transform.Find("Image (1)").gameObject.GetComponent<Image>().sprite=filledStar;
                    currentButton.transform.Find("Image (2)").gameObject.GetComponent<Image>().sprite=filledStar;
                    
                }
                else if(totalStars==2){
                    currentButton.transform.Find("Image").gameObject.GetComponent<Image>().sprite=filledStar;                   
                    currentButton.transform.Find("Image (2)").gameObject.GetComponent<Image>().sprite=filledStar;
                    
                }
                else if(totalStars==1){
                    currentButton.transform.Find("Image").gameObject.GetComponent<Image>().sprite=filledStar;                  
                }

            }
            else{
                GameObject.Find("Button "+i).GetComponent<IsButtonLockedScript>().IsLevelOpen();
                // break;
            }
        }
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
            PlayButtonScript.sandboxFlag=6;
            PlayButtonScript.levelSize=16;
            PlayButtonScript.levelDifficulty=17.5f;
        }
        else if(mapNumber==7){
            PlayButtonScript.sandboxFlag=7;
            PlayButtonScript.levelSize=18;
            PlayButtonScript.levelDifficulty=25f;
        }
        else if(mapNumber==8){
            PlayButtonScript.sandboxFlag=8;
            PlayButtonScript.levelSize=20;
            PlayButtonScript.levelDifficulty=25f;
        }
        else if(mapNumber==9){
            PlayButtonScript.sandboxFlag=9;
            PlayButtonScript.levelSize=20;
            PlayButtonScript.levelDifficulty=25f;
        }

        SceneManager.LoadScene("GameScene");
    }
}
