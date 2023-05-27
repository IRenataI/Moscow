using UnityEngine;

public class AddItem : MonoBehaviour
{
    public ItemSO Item;
    private Inventory __inventory;
    private void Awake()
    {
        __inventory = FindObjectOfType<Inventory>();
    }
    public void Add()
    {
        __inventory.AddItem(Item);
        Debug.Log("Added: " + Item.name);
    }
}
