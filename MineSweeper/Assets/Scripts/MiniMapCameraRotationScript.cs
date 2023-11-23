using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraRotationScript : MonoBehaviour
{
    void LateUpdate(){   
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y = 0;
        eulerAngles.z = 0;
        transform.eulerAngles = eulerAngles;
    }
}
