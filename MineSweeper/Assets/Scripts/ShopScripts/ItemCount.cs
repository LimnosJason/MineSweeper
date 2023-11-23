using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCount : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI itemCounterText;
    public int itemNumber;

    // Start is called before the first frame update
    void Start()
    {
        ChangeItemCounterText();
    }

    public void ChangeItemCounterText(){
        itemCounterText.text=PlayerPrefs.GetInt("item "+itemNumber).ToString();
    }

}
