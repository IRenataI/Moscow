using UnityEngine;
using System;

public class CheckItem : MonoBehaviour
{
    [SerializeField] private ItemStruct[] ItemStructe;
    private Inventory __inventory;
    private WinCondition __winCondition;
    private void Awake()
    {
        __winCondition = GetComponent<WinCondition>();
        __inventory = FindObjectOfType<Inventory>();
    }
    public void Check()
    {
        for (int i = 0; i < ItemStructe.Length; i++)
        {
            if (__inventory.RemoveItem(ItemStructe[i].Item, ItemStructe[i].Amount))
            {
                __winCondition.IncreaseHittedTargets();
            }
        }
    }
}
[Serializable] public struct ItemStruct
{
    public ItemSO Item;
    public int Amount;
}
/*
if (__inventory.ContainsItem(Item) >= Amount)
{
    __winCondition.IncreaseHittedTargets();
}
*/

//[SerializeField]private ItemSO[] Items;
//[SerializeField] private int[] Amounts;