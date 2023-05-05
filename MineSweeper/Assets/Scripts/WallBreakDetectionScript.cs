using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreakDetectionScript : MonoBehaviour
{
    [SerializeField] GameObject minePrefab;

    GameObject skyMineCounterCanvas;
    GameObject flagImage;
    GameObject mineCounterText;
    GameObject mineCounterCanvas=null;

    public Material wallFlagMaterial;
    public Material wallMaterial;

    private bool wallBreakFlag=false;
    private bool checkAllWallFlags=false;
    private bool flaggedWallFlag=false;

    private int mineWallCounter=0;
    
    void Start(){

        skyMineCounterCanvas=(transform.parent.gameObject).transform.Find("Sky MineCounter Canvas(Clone)").gameObject;
        flagImage=skyMineCounterCanvas.transform.Find("Flag Image").gameObject;
        mineCounterText=skyMineCounterCanvas.transform.Find("Mine Counter Text (TMP)").gameObject;
    
        if(transform.parent.gameObject.transform.Find("Canvas(Clone)")){
            mineCounterCanvas=(transform.parent.gameObject).transform.Find("Canvas(Clone)").gameObject;
        }
        else if(transform.parent.gameObject.transform.Find("Mine")){
            MineWallCheck(transform.forward);
            MineWallCheck(transform.right);
            MineWallCheck(-transform.right);
            MineWallCheck(-transform.forward);
        }
    }
    void Update(){
        flaggedWallFlag=false;

        Debug.DrawRay(transform.position, transform.forward * 6,Color.red);
        Debug.DrawRay(transform.position, transform.right * 6,Color.red);
        Debug.DrawRay(transform.position, -transform.right * 6,Color.red);
        Debug.DrawRay(transform.position, -transform.forward * 6,Color.red);

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
            Destroy(transform.gameObject);
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

    void CountMineWalls(Vector3 faceAt){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, faceAt, out hit, 6)) {
            if(hit.transform.name.Contains("Mine")){
                mineWallCounter++;
            }
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
            }
        }
        else{
            if (Physics.Raycast(transform.position, faceAt, out hit, 6)) {
                hit.transform.gameObject.GetComponent<MeshRenderer> ().material = wallMaterial;
            }
        }
    }
}
