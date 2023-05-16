using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTotalCoins : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI coinText;

    void Start()
    {
        coinText.text=PlayerPrefs.GetInt("coinCounter").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
