using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateDypScript : MonoBehaviour
{
    public Slider sliderVal;
    public GameObject dyp;
    public float sliderValFloat;
    
    public void RotateDyp() {
        sliderValFloat = sliderVal.value;
        dyp.transform.eulerAngles = new Vector3(dyp.transform.eulerAngles.x, -sliderValFloat, dyp.transform.eulerAngles.z
    );

    }
}
