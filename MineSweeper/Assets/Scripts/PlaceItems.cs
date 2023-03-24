using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItems : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    GameObject selectedRoom=null;

    private Vector3 savedPosition;
    private int mineNumber=5;
    private int mapRow,mapCol;
    private int[,] mapArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawningItems(int row, int col){
        mapRow=row;
        mapCol=col;
        mapArray = new int[mapRow,mapCol];
        SpawnPlayerRandomly();
        SpawnMineRandomly();
    }

    void SpawnPlayerRandomly(){ 
        int randomCol,randomRow;   

        randomRow = Random.Range(1, mapRow);
        randomCol = Random.Range(1, mapCol);
        
        findSelectedRoom(randomRow,randomCol);

        savedPosition = selectedRoom.transform.Find("Podium").position;

        GameObject instantiatedObject=Instantiate(playerPrefab);
        instantiatedObject.name = "Player";
        instantiatedObject.transform.position = savedPosition;

        mapArray[randomRow-1,randomCol-1]=2;
    }

    void SpawnMineRandomly(){
        int i,randomCol,randomRow;   
        for(i=0;i<mineNumber;i++){
            
            randomRow = Random.Range(1, mapRow);
            randomCol = Random.Range(1, mapCol);
            if(mapArray[randomRow-1,randomCol-1]==0){
                findSelectedRoom(randomRow,randomCol);
                
                savedPosition = selectedRoom.transform.Find("Podium").position;

                mapArray[randomRow-1,randomCol-1]=1;
            }
            else{
                i--;
                continue;
            }
        }
    }

    GameObject findSelectedRoom(int row,int col){
        if(col==mapCol){
            selectedRoom=GameObject.Find("Parallel Room "+row+" "+col);
        }
        else{
            selectedRoom=GameObject.Find("Corner Room "+row+" "+col);
        }
        Debug.Log(selectedRoom);
        if(!selectedRoom){
            selectedRoom=GameObject.Find("Cube Room "+row+" "+col);
        }
        return selectedRoom;
    }

    void PrintArray(){
        int i,j;
        for(i=0;i<mapRow;i++){
            for(j=0;j<mapCol;j++){
                Debug.Log(mapArray[i,j]);
            }
        }
    }
}
