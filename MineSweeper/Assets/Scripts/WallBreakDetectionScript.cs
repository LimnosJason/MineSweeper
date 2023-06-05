using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class WallBreakDetectionScript : MonoBehaviour
{
    [SerializeField] GameObject minePrefab;

    GameObject skyMineCounterCanvas;
    GameObject flagImage;
    GameObject coinImage;
    GameObject mineCounterText;
    GameObject mineCounterCanvas=null;

    public Material wallFlagMaterial;
    public Material wallMaterial;
    public bool itemFlag=false;
    public bool itemCoin=false;
    private bool wallBreakFlag=false;
    private bool checkAllWallFlags=false;
    private bool flaggedWallFlag=false;

    GameObject wallForward;
    GameObject wallRight;
    GameObject wallLeft;
    GameObject wallBackward;

    WallScript wallScriptForward;
    WallScript wallScriptRight;
    WallScript wallScriptLeft;
    WallScript wallScriptBackward;

    private bool exceptionFlag=false;

    
    void Start(){

        skyMineCounterCanvas=(transform.parent.gameObject).transform.Find("Sky MineCounter Canvas(Clone)").gameObject;
        flagImage=skyMineCounterCanvas.transform.Find("Flag Image").gameObject;
        coinImage=skyMineCounterCanvas.transform.Find("Coin Image").gameObject;
        mineCounterText=skyMineCounterCanvas.transform.Find("Mine Counter Text (TMP)").gameObject;
    
        if(transform.parent.gameObject.transform.Find("Canvas(Clone)")){
            // try {
        
                mineCounterCanvas=(transform.parent.gameObject).transform.Find("Canvas(Clone)").gameObject;
                wallForward=CanvasWallCheck(transform.forward);
                wallRight=CanvasWallCheck(transform.right);
                wallLeft=CanvasWallCheck(-transform.right);
                wallBackward=CanvasWallCheck(-transform.forward);

            
                if(!exceptionFlag){
                    wallForward.GetComponent<WallScript>().wallFlagList.Add(true);
                    wallRight.GetComponent<WallScript>().wallFlagList.Add(true);
                    wallLeft.GetComponent<WallScript>().wallFlagList.Add(true);
                    wallBackward.GetComponent<WallScript>().wallFlagList.Add(true);
                }
            // }
            // catch (Exception e) {
                
            // } 
        }
        else if(transform.parent.gameObject.transform.Find("Mine")){
            MineWallCheck(transform.forward);
            MineWallCheck(transform.right);
            MineWallCheck(-transform.right);
            MineWallCheck(-transform.forward);
        }
    }
    void Update(){
        if(itemFlag==false){
            flaggedWallFlag=false;

            // Debug.DrawRay(transform.position, transform.forward * 6,Color.red);
            // Debug.DrawRay(transform.position, transform.right * 6,Color.red);
            // Debug.DrawRay(transform.position, -transform.right * 6,Color.red);
            // Debug.DrawRay(transform.position, -transform.forward * 6,Color.red);

            CheckWall(transform.forward,false);
            CheckWall(transform.right,false);
            CheckWall(-transform.right,false);
            CheckWall(-transform.forward,false);

            if(wallBreakFlag){
                if(checkAllWallFlags){
                    if(!(transform.parent.gameObject).transform.Find("Mine")){
                        SpawnMineOnWrongAnswer();
                        SpawnMineOnWrongAnswer();
                        SpawnMineOnWrongAnswer();
                    }
                }
                mineCounterText.SetActive(true);
                if(mineCounterCanvas!=null){
                    mineCounterCanvas.SetActive(true);
                }
                else{
                    CheckWall(transform.forward,true);
                    CheckWall(transform.right,true);
                    CheckWall(-transform.right,true);
                    CheckWall(-transform.forward,true);
                }
                if(!exceptionFlag){
                    RemoveExtraWalls(wallForward);
                    RemoveExtraWalls(wallRight);
                    RemoveExtraWalls(wallLeft);
                    RemoveExtraWalls(wallBackward);
                
                    // Destroy(transform.gameObject);
                    gameObject.SetActive(false);
                }
            }
            else{
                if(!flaggedWallFlag){
                    flagImage.SetActive(false);
                    checkAllWallFlags=false;

                    ChangeWallMaterial(transform.forward,false);
                    ChangeWallMaterial(transform.right,false);
                    ChangeWallMaterial(-transform.right,false);
                    ChangeWallMaterial(-transform.forward,false);
                }
            }
        }
        else if(itemFlag){
            flagImage.SetActive(true);
            flaggedWallFlag=true;
            checkAllWallFlags=true;

            ChangeWallMaterial(transform.forward,true);
            ChangeWallMaterial(transform.right,true);
            ChangeWallMaterial(-transform.right,true);
            ChangeWallMaterial(-transform.forward,true);
        }
    }

    private void RemoveExtraWalls(GameObject wall){
        if(wall!=null){
            if(!wall.transform.name.Contains("Flagged") && !wall.transform.name.Contains("Mine") && !wall.transform.name.Contains("Border"))
            wall.GetComponent<WallScript>().wallFlagList.Remove(true);
            if(wall.GetComponent<WallScript>().wallFlagList.Count==0)
                Destroy(wall);
        }
    }

    public void CheckWall(Vector3 faceAt,bool breakWall){
        RaycastHit hit;
        // Debug.Log(mineWallCounter);
        if(breakWall){
            if (Physics.Raycast(transform.position, faceAt, out hit, 6)) { 
                if(!hit.transform.name.Contains("Flagged") && !hit.transform.name.Contains("Mine") && !hit.transform.name.Contains("Border")){
                    Destroy(hit.transform.gameObject); 
                }
            }
        }
        else{
            if (!Physics.Raycast(transform.position, faceAt, out hit, 6)) {   
            wallBreakFlag=true;
            }
            else if (hit.transform.name.Contains("Flagged")){
                flagImage.SetActive(true);
                flaggedWallFlag=true;
                checkAllWallFlags=true;

                ChangeWallMaterial(transform.forward,true);
                ChangeWallMaterial(transform.right,true);
                ChangeWallMaterial(-transform.right,true);
                ChangeWallMaterial(-transform.forward,true);
            }
            else if (hit.transform.name.Contains("RemoveF")){
                flagImage.SetActive(false);
                flaggedWallFlag=false;

                ChangeWallMaterial(transform.forward,false);
                ChangeWallMaterial(transform.right,false);
                ChangeWallMaterial(-transform.right,false);
                ChangeWallMaterial(-transform.forward,false);
            }
        }
    }

    void MineWallCheck(Vector3 faceAt){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, faceAt, out hit, 6)) {   
            if(hit.transform.name.Contains("Wall")){
                hit.transform.name="Mine Wall";
            }
        }
    }

    GameObject CanvasWallCheck(Vector3 faceAt){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, faceAt, out hit, 6)){
            Physics.Raycast(transform.position, faceAt, out hit, 6);
            return hit.transform.gameObject;
        }
        else{
            exceptionFlag=true;
            return null;
        }
    }

    void SpawnMineOnWrongAnswer(){
        GameObject instantiatedObject=Instantiate(minePrefab);
        instantiatedObject.name = "Wrong Answer Mine";
        instantiatedObject.transform.SetParent(transform.parent);
        instantiatedObject.transform.position = skyMineCounterCanvas.transform.position;
    }

    void ChangeWallMaterial(Vector3 faceAt,bool flagCheck){
        RaycastHit hit;
        if(flagCheck){
            if (Physics.Raycast(transform.position, faceAt, out hit, 6)) {
                hit.transform.gameObject.GetComponent<MeshRenderer> ().material = wallFlagMaterial;
                // if(!hit.transform.name.Contains("Flagged")&&!hit.transform.name.Contains("RemoveF")&&!hit.transform.name.Contains("Border")){
                if(hit.transform.name=="Wall"){
                    hit.transform.name="Wall HiddenF";
                }
            }
        }
        else{
            if (Physics.Raycast(transform.position, faceAt, out hit, 6)&&!hit.transform.name.Contains("Border")&&!hit.transform.name.Contains("Mine")) {
                hit.transform.gameObject.GetComponent<MeshRenderer> ().material = wallMaterial;
                hit.transform.name="Wall";
            }
        }
    }

    public void EnableCoinImage(){
        coinImage.SetActive(true);
    }
}
