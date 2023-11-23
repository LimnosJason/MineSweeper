using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTotalCoins : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI coinText;

    void Start()
    {
        UpdateTotalCoins();
    }

    public void UpdateTotalCoins(){
        coinText.text=PlayerPrefs.GetInt("coinCounter").ToString();
    }
}
