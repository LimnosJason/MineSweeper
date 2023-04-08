using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreakDetectionScript : MonoBehaviour
{
    private bool flag=false;
    void Update(){
        RaycastHit hit;
        
        Debug.DrawRay(transform.position, transform.forward * 6,Color.red);
        Debug.DrawRay(transform.position, transform.right * 6,Color.red);
        Debug.DrawRay(transform.position, -transform.right * 6,Color.red);
        Debug.DrawRay(transform.position, -transform.forward * 6,Color.red);
        if (!Physics.Raycast(transform.position, transform.forward, out hit, 6)) {   
           flag=true;
        }
        else if (!Physics.Raycast(transform.position, transform.right, out hit, 6)) {   
            flag=true;
        }
        else if (!Physics.Raycast(transform.position, -transform.right, out hit, 6)) {   
            flag=true;
        }
        else if (!Physics.Raycast(transform.position, -transform.forward, out hit, 6)) {   
            flag=true;
        }
        if(flag){
            Debug.Log("wall missing");
            // (transform.parent.gameObject).transform.Find("Sky MineCounter Canvas(Clone)").gameObject.SetActive(true);
            Destroy(transform.gameObject);
        }
    }
}
