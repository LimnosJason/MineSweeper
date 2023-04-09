using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreakDetectionScript : MonoBehaviour
{
    private bool wallBreakFlag=false;
    void Update(){
        RaycastHit hit;
        
        Debug.DrawRay(transform.position, transform.forward * 6,Color.red);
        Debug.DrawRay(transform.position, transform.right * 6,Color.red);
        Debug.DrawRay(transform.position, -transform.right * 6,Color.red);
        Debug.DrawRay(transform.position, -transform.forward * 6,Color.red);

        CheckWall(transform.forward);
        CheckWall(transform.right);
        CheckWall(-transform.right);
        CheckWall(-transform.forward);
    
        if(wallBreakFlag){
            Debug.Log("wall missing");
            (transform.parent.gameObject).transform.Find("Sky MineCounter Canvas(Clone)").gameObject.SetActive(true);
            Destroy(transform.gameObject);
        }
    }

    void CheckWall(Vector3 faceAt){
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, faceAt, out hit, 6)) {   
           wallBreakFlag=true;
        }
        else if (hit.transform.name.Contains("Flagged")){

        }
    }
}
