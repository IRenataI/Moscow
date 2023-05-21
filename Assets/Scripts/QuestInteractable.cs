using UnityEngine;

public class QuestInteractable : Interactable
{
    private Color __changedColor = Color.white;
    private Renderer __renderer;
    private Color __initialColor;
    private void Awake()
    {
        __renderer = GetComponent<Renderer>();
        __initialColor = __renderer.material.color;
    }
    public override void Select() 
    {
        base.Select();
        __renderer.material.color = __changedColor;
        Debug.Log(__renderer.material.color);
    }
    public override void Interact()
    {
        base.Interact();
    }
    public override void Deselect()
    {
        base.Deselect();
        __renderer.material.color = __initialColor;
    }
}
