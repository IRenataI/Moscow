using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    private Dictionary<ItemSO, int> items = new();

    private void Start()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
    }

    public void AddItem(ItemSO itemSO, int count = 1)
    {
        if (items.ContainsKey(itemSO))
            items[itemSO] += count;
        else
            items[itemSO] = count;
    }

    public bool RemoveItem(ItemSO itemSO, int count = 1)
    {
        if (!items.ContainsKey(itemSO) || items[itemSO] < count)
            return false;

        if (items[itemSO] == count)
            items.Remove(itemSO);
        else
            items[itemSO] -= count;

        return true;
    }

    public int ContainsItem(ItemSO itemSO)
    {
        if (items.ContainsKey(itemSO))
            return items[itemSO];

        return -1;
    }
}