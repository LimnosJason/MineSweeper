using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItems : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    GameObject selectedRoom;
    private Vector3 savedPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayerRandomlySplit(int row, int col){ 
        int randomCol,randomRow;   
        // do{
            randomRow = Random.Range(1, row);
            randomCol = Random.Range(1, col);
        // }while(mapArray[row-1,col-1]!=0);
        if(randomCol==col){
            selectedRoom=GameObject.Find("Parallel Room "+randomRow+" "+randomCol);
        }
        else{
            selectedRoom=GameObject.Find("Corner Room "+randomRow+" "+randomCol);
        }
        
        savedPosition = selectedRoom.transform.Find("Podium").position;
        playerPrefab.transform.position=savedPosition;

        Debug.Log(randomRow);
        Debug.Log(randomCol);
    }
}
