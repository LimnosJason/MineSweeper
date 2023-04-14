using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreakDetectionScript : MonoBehaviour
{
    GameObject skyMineCounterCanvas;
    GameObject flagImage;
    GameObject mineCounterText;

    private bool wallBreakFlag=false;
    private bool flaggedWallFlag=false;
    
    void Start(){
        skyMineCounterCanvas=(transform.parent.gameObject).transform.Find("Sky MineCounter Canvas(Clone)").gameObject;
        flagImage=skyMineCounterCanvas.transform.Find("Flag Image").gameObject;
        mineCounterText=skyMineCounterCanvas.transform.Find("Mine Counter Text (TMP)").gameObject;
    }
    void Update(){
        flaggedWallFlag=false;

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
            mineCounterText.SetActive(true);
            Destroy(transform.gameObject);
        }
        else{
            if(!flaggedWallFlag){
                flagImage.SetActive(false);
            }
        }
    }

    void CheckWall(Vector3 faceAt){
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, faceAt, out hit, 6)) {   
           wallBreakFlag=true;
        }
        else if (hit.transform.name.Contains("Flagged")){
            flagImage.SetActive(true);
            flaggedWallFlag=true;
        }
    }
}
