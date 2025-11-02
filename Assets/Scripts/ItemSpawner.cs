using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    public int startQty = 1;
    
    private void Start()
    {
        for (int i = 0; i < startQty; i++)
        {
            SpawnItem(items[Random.Range(0, items.Length)], new Vector2(Random.Range(0, 5), Random.Range(0, 5)));
        }
        
        EventBroadcaster.OnItemPickup += OnItemPickup;
    }

    private void OnItemPickup(IItemInterface obj)
    {
        SpawnItem(items[Random.Range(0, items.Length)], new Vector2(Random.Range(0, 5), Random.Range(0, 5)));
    }

    void SpawnItem(GameObject prefab, Vector2 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }
    
}
