using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinHitBox : MonoBehaviour
{
    [SerializeField] GameObject coinStackPrefab;
    
    PlayerStatisticsScript playerStatisticsScript;
    [SerializeField] GameObject playerStatisticsScriptObject;

    void Awake(){
        playerStatisticsScript = playerStatisticsScriptObject.GetComponent<PlayerStatisticsScript>();
    }

    private int randomCoinNumber;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Body")){
            randomCoinNumber = Random.Range(100000, 25000);
            playerStatisticsScript.SetPlayerScore(playerStatisticsScript.GetPlayerScore() + randomCoinNumber);
            Destroy(coinStackPrefab);  
        }  
    }
}
