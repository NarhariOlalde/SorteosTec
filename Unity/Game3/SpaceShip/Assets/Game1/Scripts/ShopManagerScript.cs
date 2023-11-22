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
    public LootSystem lootSystem; // Reference to the LootSystem script

    void Start()
    {
        // Initialize coins and update UI
        coins = PlayerPrefs.GetInt("total_score", 0);
        CoinsTXT.text = "Puntos: " + coins.ToString();

        // Initialize shop items (ID and price for two loot boxes)
        shopItems[1, 1] = 1; // ID for Loot Box 1
        shopItems[1, 2] = 2; // ID for Loot Box 2
        shopItems[1, 3] = 3;

        shopItems[2, 1] = 10000; // Price for Loot Box 1
        shopItems[2, 2] = 20000; // Price for Loot Box 2
        shopItems[2, 3] = 30000; // Price for Loot Box 2
    }

    public void Buy()
    {
        GameObject buttonRef = EventSystem.current.currentSelectedGameObject;
        if (buttonRef != null)
        {
            ButtonInfo buttonInfo = buttonRef.GetComponent<ButtonInfo>();
            if (buttonInfo != null)
            {
                int itemID = buttonInfo.ItemID;
                if (coins >= shopItems[2, itemID])
                {
                    // Subtract the cost and update UI
                    coins -= shopItems[2, itemID];
                    PlayerPrefs.SetInt("total_score", coins);
                    CoinsTXT.text = "Puntos: " + coins.ToString();

                    // Call the Spawner method from LootSystem
                    lootSystem.SpawnFromLootBox(itemID - 1); // Subtract 1 to match the array index

                    // Optional: Update quantity or other UI elements
                    // buttonInfo.QuantityTxt.text = "New Quantity Here";
                }
                else
                {
                    Debug.Log("Not enough coins to buy the item!");
                }
            }
            else
            {
                Debug.LogError("ButtonInfo component is missing from the button");
            }
        }
        else
        {
            Debug.LogError("No button was clicked or the button is missing an EventSystem tag");
        }
    }
}
