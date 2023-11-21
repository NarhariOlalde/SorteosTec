using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemToSpawn
{
    public GameObject item;
    public float spawnRate;
}

[System.Serializable]
public class LootBox
{
    public ItemToSpawn[] items;
}

public class LootSystem : MonoBehaviour
{
    public LootBox[] lootBoxes; // An array to hold different types of loot boxes.
    public GameObject itemRewardPanel; // The UI panel to show the reward

    void Start()
{
    // Find the itemRewardPanel by name if not assigned
    if (itemRewardPanel == null)
    {
        itemRewardPanel = GameObject.Find("itemRewardPanel");
    }

    // Initially, we don't want to show the panel
    itemRewardPanel.SetActive(false);
}


    public void SpawnFromLootBox(int boxIndex)
    {
        // Validate the boxIndex to make sure it's within the range of available loot boxes.
        if (boxIndex < 0 || boxIndex >= lootBoxes.Length)
        {
            Debug.LogError("SpawnFromLootBox index out of range: " + boxIndex);
            return;
        }

        LootBox selectedLootBox = lootBoxes[boxIndex];
        float totalSpawnRate = 0f;
        foreach (var item in selectedLootBox.items)
        {
            totalSpawnRate += item.spawnRate; // Sum up the total spawn rate for the loot box.
        }

        float randomPoint = Random.value * totalSpawnRate; // Random point within the total spawn rate.
        float currentRate = 0f;

        // Determine which item to spawn based on the randomPoint.
        foreach (var item in selectedLootBox.items)
        {
            currentRate += item.spawnRate;
            if (randomPoint <= currentRate)
            {
                // Show the item reward panel instead of instantiating the item
                ShowItemReward(item.item);
                break; // Stop once we've displayed the item.
            }
        }
    }

    private void ShowItemReward(GameObject itemPrefab)
    {
        // Find the Image component that is named 'rewardSprite'
        Image rewardImage = itemRewardPanel.transform.Find("rewardSprite").GetComponent<Image>();
        if (rewardImage != null)
        {
            rewardImage.sprite = itemPrefab.GetComponent<SpriteRenderer>().sprite;
            rewardImage.preserveAspect = true; // Preserve the sprite's aspect ratio
            itemRewardPanel.SetActive(true); // Show the panel with the item's sprite
        }
        else
        {
            Debug.LogError("rewardSprite Image not found in itemRewardPanel.");
        }
    }


    private IEnumerator HidePanelAfterDelay(GameObject panel, float delay)
    {
        yield return new WaitForSeconds(delay);
        panel.SetActive(false);
    }
}
