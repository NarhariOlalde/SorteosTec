using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{



    public int[,] shopItems = new int[5,5];
    public int coins;
    public Text CoinsTXT;
    // Start is called before the first frame update
    void Start()
    {
	coins = PlayerPrefs.GetInt("total_score", 0);
        CoinsTXT.text = "Coins:" + coins.ToString();

        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        //Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;
        //QTY
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
    }



    public void Buy() { 
    
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]) {

            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

 

            CoinsTXT.text = "Coins:" + coins.ToString();

            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++.ToString() ;
	    PlayerPrefs.SetInt("total_score", coins);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
