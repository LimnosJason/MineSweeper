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
        Debug.Log(other.name);
        if(other.name.Contains("Cube"))
            Destroy(other.gameObject);
        else if(other.name.Contains("Body")) 
            mineScript.Explode(other);
    }
}
