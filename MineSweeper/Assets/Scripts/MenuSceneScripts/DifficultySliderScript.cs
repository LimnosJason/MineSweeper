using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DifficultySliderScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI optionText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float value = slider.value;
        float interval = 0.25f; //any interval you want to round to
        value = Mathf.Round(value / interval) * interval;
        slider.value = value;
        switch(value){
            case 0.0f:
                optionText.text="Very Easy";
                break;
            case 0.25f:
                optionText.text="Easy";
                break;
            case 0.5f:
                optionText.text="Medium";
                break;
            case 0.75f:
                optionText.text="Hard";
                break;  
            case 1.0f:
                optionText.text="Impossible";
                break;      
        }   
    }
}
