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

    void Awake(){
        placeItems = placeItemsObject.GetComponent<PlaceItems>();
    }

    void Start()
    {
        PlaceRoomsMethod();
        placeItems.StartSpawningItems(mapRow, mapCol);
    }


    void Update()
    {
        
    }

    void PlaceRoomsMethod(){
        int i,j;
        mapRow=5;mapCol=5;
        savedPosition=mapGameObject.transform.position;
        //Place rooms
        for(i=0;i<mapRow;i++){
            savedPosition= savedPosition + new Vector3(-10.0f, 0.0f, mapCol*10.0f);
            for(j=0;j<mapCol;j++){
                savedPosition= savedPosition + new Vector3(0.0f, 0.0f, -10.0f);
                if(i==0&&j==0){
                    GameObject instantiatedObject=Instantiate(cornerRoomPrefab);
                    instantiatedObject.name = "Corner Room " + (i+1).ToString() + " " + (j+1).ToString();
                    instantiatedObject.transform.SetParent(mapGameObject.transform);
                    instantiatedObject.transform.position = savedPosition;
                }
                else if(i==mapRow-1){
                    if(j==0){
                        GameObject instantiatedObject=Instantiate(cubeRoomPrefab);
                        instantiatedObject.name = "Cube Room " + (i+1).ToString() + " " + (j+1).ToString();
                        instantiatedObject.transform.SetParent(mapGameObject.transform);
                        instantiatedObject.transform.position = savedPosition;
                    }
                    else if(j==mapCol-1){
                        GameObject instantiatedObject=Instantiate(cubeRoomPrefab);
                        instantiatedObject.name = "Cube Room " + (i+1).ToString() + " " + (j+1).ToString();
                        instantiatedObject.transform.SetParent(mapGameObject.transform);
                        instantiatedObject.transform.position = savedPosition;
                    }
                    else{
                        GameObject instantiatedObject=Instantiate(parallelRoomPrefab);
                        instantiatedObject.name = "Paraller Room " + (i+1).ToString() + " " + (j+1).ToString();
                        instantiatedObject.transform.SetParent(mapGameObject.transform);
                        instantiatedObject.transform.position = savedPosition;
                        instantiatedObject.transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
                    }
                }
                else if(j==mapCol-1){
                    GameObject instantiatedObject=Instantiate(parallelRoomPrefab);
                    instantiatedObject.name = "Paraller Room " + (i+1).ToString() + " " + (j+1).ToString();
                    instantiatedObject.transform.SetParent(mapGameObject.transform);
                    instantiatedObject.transform.position = savedPosition;
                }
                else{
                    GameObject instantiatedObject=Instantiate(cornerRoomPrefab);
                    instantiatedObject.name = "Corner Room " + (i+1).ToString() + " " + (j+1).ToString();
                    instantiatedObject.transform.SetParent(mapGameObject.transform);
                    instantiatedObject.transform.position = savedPosition;
                }
            }
        }
    }
}
