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

    PlayerStatisticsScript playerStatisticsScript;
    [SerializeField] GameObject playerStatisticsScriptObject;

    MineScript mineScript;

    CoinHitBox coinHitBox;
    
    private Vector3 savedPosition;
    private int mineNumber;
    private int coinNumber;
    private int mapRow,mapCol;
    private int[,] mapArray;

    private static List<GameObject> totalMinesList = new List<GameObject>();
    private static List<GameObject> totalCoinsList = new List<GameObject>();
    private static List<GameObject> clonedTotalCoinsList;
    
    void Awake(){
        totalMinesList.Clear();
        totalCoinsList.Clear();
        playerStatisticsScript = playerStatisticsScriptObject.GetComponent<PlayerStatisticsScript>();
    }

    public void StartSpawningItems(int row, int col){
        mapRow=row;
        mapCol=col;
        mapArray = new int[mapRow,mapCol];
        mineNumber=(mapRow*mapCol)*(int)PlayButtonScript.levelDifficulty/100;
        coinNumber=(mapRow*mapCol)*(int)PlayButtonScript.levelDifficulty/100;
        playerStatisticsScript.StartPlayFlag(mineNumber);


        SpawnPlayerRandomly();
        SpawnMineRandomly();
        SpawnCoinRandomly();
        PlaceWallBreakDetection();
        CountMines();
        PrintArray();
    }

    void SpawnPlayerRandomly(){ 
        int randomCol,randomRow;   

        randomRow = Random.Range(1, mapRow+1);
        randomCol = Random.Range(1, mapCol+1);
        
        Debug.Log(randomRow);
        Debug.Log(randomCol);
        FindSelectedRoom(randomRow,randomCol);

        savedPosition = selectedRoom.transform.Find("Podium").position;

        // GameObject instantiatedObject=Instantiate(playerPrefab);
        // instantiatedObject.name = "Player";
        // instantiatedObject.transform.position = savedPosition;
        // instantiatedObject.transform.Find("Body").position= savedPosition;

        // playerPrefab.transform.position=savedPosition;

        mapArray[randomRow-1,randomCol-1]=2;
    }

    void SpawnMineRandomly(){
        int i,randomCol,randomRow;   
        // print("MAP ROW"+mapRow);
        for(i=0;i<mineNumber;i++){
            do{
                randomRow = Random.Range(1, mapRow+1);
                randomCol = Random.Range(1, mapCol+1);
            }while(randomRow==0||randomCol==5); 
            // print("RANDOM ROW"+randomRow);
            if(mapArray[randomRow-1,randomCol-1]==0){
                Debug.Log(randomRow);
                Debug.Log(randomCol);
                FindSelectedRoom(randomRow,randomCol);
                
                savedPosition = selectedRoom.transform.Find("Podium").position;

                GameObject instantiatedObject=Instantiate(minePrefab);
                instantiatedObject.name = "Mine";
                instantiatedObject.transform.SetParent(selectedRoom.transform);
                instantiatedObject.transform.position = savedPosition;

                totalMinesList.Add(instantiatedObject);
                
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
             do{
                randomRow = Random.Range(1, mapRow+1);
                randomCol = Random.Range(1, mapCol+1);
            }while(randomRow==0||randomCol==5); 
            if(mapArray[randomRow-1,randomCol-1]==0){
                FindSelectedRoom(randomRow,randomCol);
                
                savedPosition = selectedRoom.transform.Find("Podium").position;

                GameObject instantiatedObject=Instantiate(coinPrefab);
                instantiatedObject.name = "Coin";
                instantiatedObject.transform.SetParent(selectedRoom.transform);
                instantiatedObject.transform.position = savedPosition;

                totalCoinsList.Add(instantiatedObject);

                mapArray[randomRow-1,randomCol-1]=3;
            }
            else{
                i--;
                continue;
            }
        }
        clonedTotalCoinsList = new List<GameObject>(totalCoinsList);
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
                count=0;
                if(mapArray[i,j]==1){
                    ChangeMineCountText(count,i+1,j+1);
                    continue;
                }
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
        if(mapArray[row-1,col-1]==2)
            skyMineCounterText.transform.Find("Mine Counter Text (TMP)").gameObject.SetActive(true);;

        
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

    public GameObject GetRandomMine(){
        int randomPosition;
        do{
            randomPosition = Random.Range(0, totalMinesList.Count);
            mineScript = totalMinesList[randomPosition].GetComponent<MineScript>();
        }while(mineScript.movementSpeed!=15);
        return totalMinesList[randomPosition];
    }

    public GameObject GetRandomCoin(){
        int randomPosition;
        bool repeat;
        GameObject sentCoin;
        do{
            if(totalCoinsList.Count==0){
                return null;
            }
            do{
                repeat=false;
                randomPosition = Random.Range(0, totalCoinsList.Count);
                if(totalCoinsList[randomPosition]==null){
                    totalCoinsList.RemoveAt(randomPosition);
                    repeat=true;
                }
            }while(repeat);
            if(totalCoinsList[randomPosition].transform.parent.gameObject.transform.Find("WallBreakDetection")==null){
                totalCoinsList.RemoveAt(randomPosition);
                repeat=true;
            }
        }while(repeat);
        sentCoin=totalCoinsList[randomPosition];
        totalCoinsList.RemoveAt(randomPosition);
        return sentCoin;
    }

    public void ActivateAllCoins(){
        int i;
        bool canUseMagnet;
        for(i=0;i<clonedTotalCoinsList.Count;i++){
            coinHitBox = clonedTotalCoinsList[i].GetComponent<CoinHitBox>();
            if(coinHitBox!=null){
                canUseMagnet=coinHitBox.MagnetActivate();
                if(canUseMagnet){
                    clonedTotalCoinsList.RemoveAt(i);
                }
            }
            else{
                clonedTotalCoinsList.RemoveAt(i);
            }
        }
    }
}
