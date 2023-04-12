using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraZoomScript : MonoBehaviour
{
    public Camera miniMapCamera ;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel")>0 && miniMapCamera.orthographicSize > 15 ){//forward
            miniMapCamera.orthographicSize -= 2;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") <0 && miniMapCamera.orthographicSize < 45 ){//backward
            miniMapCamera.orthographicSize += 2;
        }
    }
}
