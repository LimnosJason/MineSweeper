using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItems : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject mineCounterPrefab;

    GameObject selectedRoom=null;
    
    ChangeTextScript changeTextScript;
    [SerializeField] GameObject changeTextScriptObject;

    private Vector3 savedPosition;
    private int mineNumber=75;
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
        CountMines();
    }

    void SpawnPlayerRandomly(){ 
        int randomCol,randomRow;   

        randomRow = Random.Range(1, mapRow+1);
        randomCol = Random.Range(1, mapCol+1);
        
        FindSelectedRoom(randomRow,randomCol);

        savedPosition = selectedRoom.transform.Find("Podium").position;

        GameObject instantiatedObject=Instantiate(playerPrefab);
        instantiatedObject.name = "Player";
        instantiatedObject.transform.position = savedPosition;

        mapArray[randomRow-1,randomCol-1]=2;
    }

    void SpawnMineRandomly(){
        int i,randomCol,randomRow;   
        print("MAP ROW"+mapRow);
        for(i=0;i<mineNumber;i++){
            
            randomRow = Random.Range(1, mapRow+1);
            randomCol = Random.Range(1, mapCol+1);
            print("RANDOM ROW"+randomRow);
            if(mapArray[randomRow-1,randomCol-1]==0){
                FindSelectedRoom(randomRow,randomCol);
                
                savedPosition = selectedRoom.transform.Find("Podium").position;

                mapArray[randomRow-1,randomCol-1]=1;
            }
            else{
                i--;
                continue;
            }
        }
    }

    GameObject FindSelectedRoom(int row,int col){
        if(col==mapCol || row==mapCol){
            selectedRoom=GameObject.Find("Parallel Room "+row+" "+col);
        }
        else{
            selectedRoom=GameObject.Find("Corner Room "+row+" "+col);
        }
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

    void CountMines(){
        int i,j,k,l,count;
        for(i=0;i<mapRow;i++){
            for(j=0;j<mapCol;j++){
                if(mapArray[i,j]==1){
                    continue;
                }
                count=0;
                for(k=-1;k<=1;k++){
                    for(l=-1;l<=1;l++){
                        if(i+k<5 && i+k>=0 && j+l<5 && j+l>=0 && (k!=0 || l!=0)){
                            if(mapArray[i+k,j+l]==1){
                                count++;
                            }
                        }
                    }
                }
                // Debug.Log(count);
                ChangeMineCountText(count,i+1,j+1);
            }
        }
    }

    void ChangeMineCountText(int count,int row,int col){
        GameObject selectedRoom=FindSelectedRoom(row,col);

        savedPosition = selectedRoom.transform.Find("Podium").position;
        savedPosition.y = 4f;

        GameObject mineCounterText=Instantiate(mineCounterPrefab);
        mineCounterText.transform.SetParent(selectedRoom.transform);
        mineCounterText.transform.position = savedPosition;

        changeTextScriptObject=mineCounterText;
        changeTextScript = changeTextScriptObject.GetComponent<ChangeTextScript>();
        changeTextScript.ChangeMineCounterText(count);
    }
}
