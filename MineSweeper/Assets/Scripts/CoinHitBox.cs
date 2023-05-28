using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinHitBox : MonoBehaviour
{
    public GameObject target;
    
    [SerializeField] GameObject coinStackPrefab;
    
    PlayerStatisticsScript playerStatisticsScript;
    [SerializeField] GameObject playerStatisticsScriptObject;

    private bool magnetActivated=false;

    private GameObject wallBreakDetectionGameObject;

    void Awake(){
        playerStatisticsScript = playerStatisticsScriptObject.GetComponent<PlayerStatisticsScript>();
    }
    void Start(){
        target = GameObject.Find("Body");
        wallBreakDetectionGameObject=transform.parent.gameObject.transform.Find("WallBreakDetection").gameObject;
    }

    private int randomCoinNumber;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Body")){
            playerStatisticsScript.PlayCoinSound();
            randomCoinNumber = Random.Range(100000, 25000);
            playerStatisticsScript.SetPlayerScore(playerStatisticsScript.GetPlayerScore() + randomCoinNumber);
            Destroy(coinStackPrefab);  
        }  
    }

    public bool MagnetActivate(){
        if(wallBreakDetectionGameObject==null){
            magnetActivated=true;
            return true;
        }
        return false;
    }
    
    void Update(){
        if(magnetActivated){
            transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * 35);
        }
    }

}
