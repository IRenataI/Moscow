using UnityEngine;

public class CheckItem : MonoBehaviour
{
    [SerializeField]private ItemSO[] Items;
    [SerializeField] private int[] Amounts;
    private Inventory __inventory;
    private WinCondition __winCondition;
    private void Awake()
    {
        __winCondition = GetComponent<WinCondition>();
        __inventory = FindObjectOfType<Inventory>();
    }
    public void Check()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (__inventory.RemoveItem(Items[i], Amounts[i]))
            {
                __winCondition.IncreaseHittedTargets();
            }
        }
    }
}
/*
if (__inventory.ContainsItem(Item) >= Amount)
{
    __winCondition.IncreaseHittedTargets();
}
*/