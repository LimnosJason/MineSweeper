using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    [SerializeField] GameObject playerBody;
    Rigidbody rb;
    public int fallSpeed=100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void PlayerDeath(){
        if((int)Time.timeScale==1){
            Debug.Log("w");
            playerBody.transform.Rotate(-90,0,0);
            Time.timeScale = 0;
        }
    }
}
