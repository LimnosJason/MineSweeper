using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineHitBox : MonoBehaviour
{

    MineScript mineScript;
    [SerializeField] GameObject mineScriptObject;

    PlayerDeathScript playerDeathScript;
    [SerializeField] GameObject playerDeathScriptObject;

    void Awake(){
        mineScript = mineScriptObject.GetComponent<MineScript>();
        playerDeathScript = playerDeathScriptObject.GetComponent<PlayerDeathScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.name.Contains("Wall"))
            Destroy(other.gameObject);
        else if(other.name.Contains("Body")) {
            mineScript.Explode(other);
            playerDeathScript.PlayerDeath();
        }
            
    }
}
