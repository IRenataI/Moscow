using UnityEngine;

public class QuestInteractable : Interactable
{
    public Canvas ButtonToPress;
    private Color __changedColor = Color.white;
    private Renderer __renderer;
    private Color __initialColor;
    private void Awake()
    {
        __renderer = GetComponent<Renderer>();
        __initialColor = __renderer.material.color;
        ButtonToPress.enabled = false;
    }
    public override void Select() 
    {
        base.Select();
        __renderer.material.color = __changedColor;
        ButtonToPress.enabled = true;
    }
    public override void Interact()
    {
        base.Interact();
        ButtonToPress.enabled = false;
    }
    public override void Deselect()
    {
        base.Deselect();
        __renderer.material.color = __initialColor;
        ButtonToPress.enabled = false;
    }
}
