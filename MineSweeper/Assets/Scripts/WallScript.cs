using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public List<bool> wallFlagList = new List<bool>();
    public string startName;

    void Start(){
        startName=gameObject.transform.name;
    }
}
