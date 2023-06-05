using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    [SerializeField] GameObject cornerRoomPrefab;
    [SerializeField] GameObject parallelRoomPrefab;
    [SerializeField] GameObject cubeRoomPrefab;
    [SerializeField] GameObject mapGameObject;

    private Vector3 savedPosition;

    PlaceItems placeItems;
    [SerializeField] GameObject placeItemsObject;

    private int mapRow,mapCol;

    private bool isDone1=false;
    private bool isDone2=false;

    public List<GameObject> mapsList = new List<GameObject>();

    void Awake(){
        placeItems = placeItemsObject.GetComponent<PlaceItems>();
    }

    void Start()
    {
        mapRow=(int)PlayButtonScript.levelSize;
        mapCol=(int)PlayButtonScript.levelSize;
        mapsList[mapRow-5].SetActive(true);
        // PlaceRoomsMethod();
        //  if(isDone1&&isDone2)
            placeItems.StartSpawningItems(mapRow, mapCol);
    }

    void Update()
    {
        
    }

    void PlaceRoomsMethod(){
        int i,j;
        GameObject instantiatedObject;
        savedPosition=mapGameObject.transform.position;
        //Place rooms
        for(i=0;i<mapRow;i++){
            savedPosition= savedPosition + new Vector3(-10.0f, 0.0f, mapCol*10.0f);
            for(j=0;j<mapCol;j++){
                savedPosition= savedPosition + new Vector3(0.0f, 0.0f, -10.0f);
                if(i==0&&j==0){
                    instantiatedObject=Instantiate(cornerRoomPrefab);
                    instantiatedObject.name = "Corner Room " + (i+1).ToString() + " " + (j+1).ToString();
                    instantiatedObject.transform.SetParent(mapGameObject.transform);
                    instantiatedObject.transform.position = savedPosition;
                }
                else if(i==mapRow-1){
                    if(j==mapCol-1){
                        instantiatedObject=Instantiate(cubeRoomPrefab);
                        instantiatedObject.name = "Cube Room " + (i+1).ToString() + " " + (j+1).ToString();
                        instantiatedObject.transform.SetParent(mapGameObject.transform);
                        instantiatedObject.transform.position = savedPosition;
                    }
                    else{
                        instantiatedObject=Instantiate(parallelRoomPrefab);
                        instantiatedObject.name = "Parallel Room " + (i+1).ToString() + " " + (j+1).ToString();
                        instantiatedObject.transform.SetParent(mapGameObject.transform);
                        instantiatedObject.transform.position = savedPosition;
                        instantiatedObject.transform.Rotate(0.0f, 270.0f, 0.0f, Space.World);
                    }
                }
                else if(j==mapCol-1){
                    instantiatedObject=Instantiate(parallelRoomPrefab);
                    instantiatedObject.name = "Parallel Room " + (i+1).ToString() + " " + (j+1).ToString();
                    instantiatedObject.transform.SetParent(mapGameObject.transform);
                    instantiatedObject.transform.position = savedPosition;
                }
                else{
                    instantiatedObject=Instantiate(cornerRoomPrefab);
                    instantiatedObject.name = "Corner Room " + (i+1).ToString() + " " + (j+1).ToString();
                    instantiatedObject.transform.SetParent(mapGameObject.transform);
                    instantiatedObject.transform.position = savedPosition;
                }
                SetBorders(i,j,instantiatedObject);
            }
        }
        isDone1=true;
    }

    void SetBorders(int row,int col,GameObject selectedRoom){
        isDone2=false;
        if(row==0){
            selectedRoom.transform.Find("Walls").transform.Find("Wall 1").name="Border";
        }
        else if(row==mapRow-1){
            if(selectedRoom.transform.name.Contains("Cube"))
                selectedRoom.transform.Find("Walls").transform.Find("Wall 4").name="Border";
            else
                selectedRoom.transform.Find("Walls").transform.Find("Wall 2").name="Border";
        }
        if(col==0){
            if(selectedRoom.transform.name.Contains("Corner"))
                selectedRoom.transform.Find("Walls").transform.Find("Wall 2").name="Border";
            else if(selectedRoom.transform.name.Contains("Parallel"))
                selectedRoom.transform.Find("Walls").transform.Find("Wall 1").name="Border";
        }
        else if(col==mapCol-1){
            selectedRoom.transform.Find("Walls").transform.Find("Wall 3").name="Border";
        }
        isDone2=true;
    }
}
