using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    [SerializeField] Slider levelSizeSlider;
    [SerializeField] Slider levelDifficultySlider;

    public static float levelSize;
    public static float levelDifficulty;

    public void StartGameMethod(){
        levelSize=levelSizeSlider.value;
        levelDifficulty=DifficultySliderScript.difficultyPercentage;

          SceneManager.LoadScene("GameScene");
    }
}
