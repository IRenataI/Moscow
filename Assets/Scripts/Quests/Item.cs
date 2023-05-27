using Unity.VisualScripting;
using UnityEngine;
public class Item : Interactable
{
    [SerializeField]private ItemSO __itemSO;
    public override void Interact()
    {
        base.Interact();
        Inventory.Instance.AddItem(__itemSO);
        Debug.Log("added: " + __itemSO.name);
        Destroy(gameObject);
    }
}
