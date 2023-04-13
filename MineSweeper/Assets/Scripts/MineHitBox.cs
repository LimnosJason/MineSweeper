using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineHitBox : MonoBehaviour
{

    MineScript mineScript;
    [SerializeField] GameObject mineScriptObject;

    void Awake(){
        mineScript = mineScriptObject.GetComponent<MineScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Wall")){
            Destroy(other.gameObject);
        }
        else if(other.name.Contains("Dyp")) {
            mineScript.Explode(other);
        }
            
    }
}
