using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SoldOutScript : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI soldOutText;
    [SerializeField] int itemNumber;

    void Start()
    {
        RefreshButton();
    }

    public void RefreshButton(){
        if(PlayerPrefs.GetInt("item "+itemNumber)==1){
            gameObject.GetComponent<Button>().interactable = false;
            soldOutText.gameObject.SetActive(true);
        }
    }
}
