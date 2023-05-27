using UnityEngine;

public class CheckItem : MonoBehaviour
{
    public ItemSO Item;
    private Inventory __inventory;
    private WinCondition __winCondition;
    private void Awake()
    {
        __winCondition = GetComponent<WinCondition>();
        __inventory = FindObjectOfType<Inventory>();
    }
    public void Check()
    {
        if (__inventory.ContainsItem(Item) > 0)
        {
            __winCondition.IncreaseHittedTargets();
        }
    }
}
