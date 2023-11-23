using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Camera mainCamera ;
    public Material wallMaterial;
    public AudioSource flagWallSound;
    RaycastHit hit;
    Ray ray;

    PlayerStatisticsScript playerStatisticsScript;
    [SerializeField] GameObject playerStatisticsScriptObject;
    
    void Awake(){
        playerStatisticsScript = playerStatisticsScriptObject.GetComponent<PlayerStatisticsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&Time.timeScale != 0){
            ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            if (Physics.Raycast(ray, out hit)){
                if(hit.transform.name.Contains("Wall"))
                    Destroy(hit.transform.gameObject);
            }
        }
        else if(Input.GetMouseButtonDown(1)&&Time.timeScale != 0){
            // Debug.Log(hit.transform.gameObject.GetComponent<Renderer>().material);
            ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            if (Physics.Raycast(ray, out hit)){
                if (hit.transform.name.Contains("Flagged")||hit.transform.name.Contains("HiddenF")){
                    hit.transform.name="Wall RemoveF";
                    playerStatisticsScript.SetPlayerFlag(1);
                }
                else if(hit.transform.name.Contains("Wall")){
                    if(playerStatisticsScript.GetPlayerFlag()>0){
                        flagWallSound.Play(0);
                        hit.transform.name="Flagged Wall";
                        playerStatisticsScript.SetPlayerFlag(-1);  
                    }
                }
            }
        }
    }

}
