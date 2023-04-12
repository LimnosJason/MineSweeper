using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Camera mainCamera ;
    RaycastHit hit;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
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
            ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            if (Physics.Raycast(ray, out hit)){
                if (hit.transform.name.Contains("Flagged")){
                    hit.transform.name="Wall";
                }
                else if(hit.transform.name.Contains("Wall")){
                    hit.transform.name="Flagged Wall";
                }
            }
        }
    }

}
