using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItems : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject mineCounterPrefab;
    [SerializeField] GameObject skyMineCounterPrefab;

    GameObject selectedRoom=null;
    
    ChangeTextScript changeTextScript;
    [SerializeField] GameObject changeTextScriptObject;
    [SerializeField] GameObject minePrefab;
    [SerializeField] GameObject wallBreakDetectionPrefab;
    [SerializeField] GameObject coinPrefab;

    private Vector3 savedPosition;
    private int mineNumber;
    private int coinNumber;
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
        mineNumber=(mapRow*mapCol)*(int)PlayButtonScript.levelDifficulty/100;
        coinNumber=(mapRow*mapCol)*(int)PlayButtonScript.levelDifficulty/100;

        SpawnPlayerRandomly();
        SpawnMineRandomly();
        SpawnCoinRandomly();
        PlaceWallBreakDetection();
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
        // print("MAP ROW"+mapRow);
        for(i=0;i<mineNumber;i++){
            
            randomRow = Random.Range(1, mapRow+1);
            randomCol = Random.Range(1, mapCol+1);
            // print("RANDOM ROW"+randomRow);
            if(mapArray[randomRow-1,randomCol-1]==0){
                FindSelectedRoom(randomRow,randomCol);
                
                savedPosition = selectedRoom.transform.Find("Podium").position;

                GameObject instantiatedObject=Instantiate(minePrefab);
                instantiatedObject.name = "Mine " + (i+1).ToString();
                instantiatedObject.transform.SetParent(selectedRoom.transform);
                instantiatedObject.transform.position = savedPosition;

                mapArray[randomRow-1,randomCol-1]=1;
            }
            else{
                i--;
                continue;
            }
        }
    }

    void SpawnCoinRandomly(){
        int i,randomCol,randomRow;   
        for(i=0;i<coinNumber;i++){   
            randomRow = Random.Range(1, mapRow+1);
            randomCol = Random.Range(1, mapCol+1);
            if(mapArray[randomRow-1,randomCol-1]==0){
                FindSelectedRoom(randomRow,randomCol);
                
                savedPosition = selectedRoom.transform.Find("Podium").position;

                GameObject instantiatedObject=Instantiate(coinPrefab);
                instantiatedObject.name = "Coin";
                instantiatedObject.transform.SetParent(selectedRoom.transform);
                instantiatedObject.transform.position = savedPosition;

                mapArray[randomRow-1,randomCol-1]=3;
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
        string str;
        for(i=0;i<mapRow;i++){
            str = "";
            for(j=0;j<mapCol;j++){
                str+=mapArray[i,j]+" ";
            }
            Debug.Log(str);
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
                        if(i+k<mapRow && i+k>=0 && j+l<mapCol && j+l>=0 && (k!=0 || l!=0)){
                            if(mapArray[i+k,j+l]==1){
                                count++;
                            }
                        }
                    }
                }
                ChangeMineCountText(count,i+1,j+1);
            }
        }
    }

    void ChangeMineCountText(int count,int row,int col){
        GameObject selectedRoom=FindSelectedRoom(row,col);

        savedPosition = selectedRoom.transform.Find("Podium").position;
        savedPosition.y = 4f;

        GameObject skyMineCounterText=Instantiate(skyMineCounterPrefab);
        skyMineCounterText.transform.SetParent(selectedRoom.transform);
        skyMineCounterText.transform.position = savedPosition;

        if(count>0){
            GameObject mineCounterText=Instantiate(mineCounterPrefab);
            mineCounterText.transform.SetParent(selectedRoom.transform);
            mineCounterText.transform.position = savedPosition;

            changeTextScriptObject=mineCounterText;
            changeTextScript = changeTextScriptObject.GetComponent<ChangeTextScript>();
            changeTextScript.ChangeMineCounterText(count);

            changeTextScriptObject=skyMineCounterText;
            changeTextScript = changeTextScriptObject.GetComponent<ChangeTextScript>();
            changeTextScript.ChangeMineCounterText(count);
        }

        
    }

    void PlaceWallBreakDetection(){
        int row,col;
        GameObject selectedRoom;
        GameObject instantiatedObject;
        for(row=0;row<mapRow;row++){
            for(col=0;col<mapCol;col++){
                if(mapArray[row,col]!=2){
                    selectedRoom = FindSelectedRoom(row+1,col+1);
                    
                    savedPosition = selectedRoom.transform.Find("Podium").position;
                    savedPosition.y=3f;

                    instantiatedObject = Instantiate(wallBreakDetectionPrefab);
                    instantiatedObject.name = "WallBreakDetection";
                    instantiatedObject.transform.SetParent(selectedRoom.transform);
                    instantiatedObject.transform.position = savedPosition;
                }
            }
        }    
    }
}
