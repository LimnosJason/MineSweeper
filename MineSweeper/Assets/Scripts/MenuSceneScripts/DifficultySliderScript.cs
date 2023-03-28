using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DifficultySliderScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI optionText;

    public static float difficultyPercentage=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(slider.value){
            case 0f:
                optionText.text="Very Easy";
                difficultyPercentage=10f;
                break;
            case 1f:
                optionText.text="Easy";
                difficultyPercentage=13.75f;
                break;
            case 2f:
                optionText.text="Medium";
                difficultyPercentage=17.5f;
                break;
            case 3f:
                optionText.text="Hard";
                difficultyPercentage=21.25f;
                break;  
            case 4f:
                optionText.text="Impossible";
                difficultyPercentage=25f;
                break;      
        }   
    }
}
