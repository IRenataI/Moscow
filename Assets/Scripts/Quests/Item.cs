using UnityEngine;
public class Item : Interactable
{
    [SerializeField]private ItemSO __itemSO;
    private Renderer __renderer;
    private Color __initialColor;
    public Color __changedColor = Color.yellow;
    private void Awake()
    {
        __renderer = GetComponent<Renderer>();
        __initialColor = __renderer.material.color;
    }
    public override void Select()
    {
        base.Select();
        __renderer.material.color = __changedColor;
    }
    public override void Interact()
    {
        base.Interact();
        Inventory.Instance.AddItem(__itemSO);
        //Debug.Log("added: " + __itemSO.name);

        __renderer.material.color = __initialColor;

        Destroy(gameObject);
    }
    public override void Deselect()
    {
        base.Deselect();
        __renderer.material.color = __initialColor;
    }
}
