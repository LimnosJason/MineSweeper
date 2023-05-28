using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyShopItemScript : MonoBehaviour
{
    public Material hatColor;

    private int playerCoins;

    ShowTotalCoins showTotalCoins;
    [SerializeField] GameObject showTotalCoinsObject;

    void Awake(){
        showTotalCoins = showTotalCoinsObject.GetComponent<ShowTotalCoins>();
    }

    void Start(){
        playerCoins=PlayerPrefs.GetInt("coinCounter");
        
    }
    
    public void BuyItem(int itemCost){
        if(playerCoins<itemCost){
            Debug.Log("Not Enough Coins");
        }
        else{
            playerCoins-=itemCost;
            PlayerPrefs.SetInt("coinCounter",PlayerPrefs.GetInt("coinCounter")-itemCost);
            showTotalCoins.UpdateTotalCoins();
            if(itemCost==1000){
                PlayerPrefs.SetInt("item 1",PlayerPrefs.GetInt("item 1")+1);
            }
            else if(itemCost==2500){
                PlayerPrefs.SetInt("item 2",PlayerPrefs.GetInt("item 2")+1);
            }
            else if(itemCost==5000){
                PlayerPrefs.SetInt("item 3",PlayerPrefs.GetInt("item 3")+1);
            }
            else if(itemCost==10000){
                hatColor.SetColor("_Color", new Color(Random.Range(0.0f, 1.1f), Random.Range(0.0f, 1.1f), Random.Range(0.0f, 1.1f), 1));
            }
            else if(itemCost==20000){
                PlayerPrefs.SetInt("item 5",1);
            }
            else if(itemCost==50000){
                PlayerPrefs.SetInt("item 6",1);
            }
        }
    }
}
