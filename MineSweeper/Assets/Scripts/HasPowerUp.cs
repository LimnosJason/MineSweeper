using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasPowerUp : MonoBehaviour
{
    public GameObject powerUpGameObject;
    public int itemNumber;

    void Awake(){
        // 
    }

    // Start is called before the first frame update
    void Start()
    {  
        powerUpGameObject.SetActive(false);
        if (PlayerPrefs.HasKey("item "+itemNumber)){
            if(PlayerPrefs.GetInt("item "+itemNumber)==1){
                powerUpGameObject.SetActive(true);
            }
        }        
    }

}
