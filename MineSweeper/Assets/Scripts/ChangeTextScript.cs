using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeTextScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mineCounterText;
    
    public void ChangeMineCounterText(int count){
        if(count!=0){
            mineCounterText.text=count.ToString();
            if(count==1)
                mineCounterText.color = new Color32( 0 , 122 , 254, 255 );//blue
            else if(count==2)
                mineCounterText.color = new Color32( 0 , 254 , 111, 255 );//green
            else if(count==3)
                mineCounterText.color = new Color32( 254 , 9 , 0, 255 );//red
            else if(count==4)
                mineCounterText.color = new Color32( 60 , 0 , 254, 255 );//navy
            else if(count==5)
                mineCounterText.color = new Color32(139, 69, 19, 255);
        }
    }
}
