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

        items[itemSO] -= count;

        return true;
    }

    /// <returns> Количество, если вещь содержится в инвентаре. "-1", если нет. </returns>
    public int ContainsItem(ItemSO itemSO)
    {
        if (items.ContainsKey(itemSO))
            return items[itemSO];

        return -1;
    }
}