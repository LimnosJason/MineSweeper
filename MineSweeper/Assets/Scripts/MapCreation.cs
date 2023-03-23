using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    [SerializeField] GameObject cornerRoomPrefab;
    [SerializeField] GameObject parallelRoomPrefab;
    [SerializeField] GameObject mapGameObject;

    private Vector3 savedPosition;

    PlaceItems placeItems;
    [SerializeField] GameObject placeItemsObject;

    private int row,col;

    void Awake(){
        placeItems = placeItemsObject.GetComponent<PlaceItems>();
    }

    void Start()
    {
        PlaceRoomsMethod();
        placeItems.SpawnPlayerRandomlySplit(row, col);
    }


    void Update()
    {
        
    }

    void PlaceRoomsMethod(){
        int i,j;
        row=5;col=5;
        savedPosition=mapGameObject.transform.position;
        //Place rooms
        for(i=0;i<row;i++){
            savedPosition= savedPosition + new Vector3(-10.0f, 0.0f, col*10.0f);
            for(j=0;j<col;j++){
                savedPosition= savedPosition + new Vector3(0.0f, 0.0f, -10.0f);
                if(i==0&&j==0){
                    GameObject instantiatedObject=Instantiate(cornerRoomPrefab);
                    instantiatedObject.name = "Corner Room " + (i+1).ToString() + " " + (j+1).ToString();
                    instantiatedObject.transform.SetParent(mapGameObject.transform);
                    instantiatedObject.transform.position = savedPosition;
                }
                else if(j==col-1){
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
