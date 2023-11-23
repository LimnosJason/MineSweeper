using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IsButtonLockedScript : MonoBehaviour
{
    GameObject lockImage;
    // Start is called before the first frame update
    public void IsLevelOpen()
    {
        lockImage=transform.Find("Lock").gameObject;
        if(lockImage.activeSelf){
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

}
