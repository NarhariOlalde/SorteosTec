using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemToSpawn
{
    public GameObject item; // The actual item GameObject that will be spawned.
    public float spawnRate; // The rate (or probability) at which this item will be spawned.
}

[System.Serializable]
public class LootBox
{
    public ItemToSpawn[] items; // An array of items that this loot box can spawn.
}

public class LootSystem : MonoBehaviour
{
    public LootBox[] lootBoxes; // An array to hold different types of loot boxes.

    // Method to spawn an item from a specific loot box.
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
                Instantiate(item.item, transform.position, Quaternion.identity); // Spawn the item.
                break; // Stop once we've spawned the item.
            }
        }
    }
}
