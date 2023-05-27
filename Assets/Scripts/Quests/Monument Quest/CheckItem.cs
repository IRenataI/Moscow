using UnityEngine;

public class CheckItem : MonoBehaviour
{
    public ItemSO Item;
    public int Amount = -1;
    private Inventory __inventory;
    private WinCondition __winCondition;
    private void Awake()
    {
        __winCondition = GetComponent<WinCondition>();
        __inventory = FindObjectOfType<Inventory>();
    }
    public void Check()
    {
        if (__inventory.ContainsItem(Item) >= Amount)
        {
            __winCondition.IncreaseHittedTargets();
        }
    }
}
