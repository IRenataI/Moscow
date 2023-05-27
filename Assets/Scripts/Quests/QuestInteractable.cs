using UnityEngine;

public class QuestInteractable : Interactable
{
    public Canvas ButtonToPress;
    private Color __changedColor = Color.white;
    private Renderer __renderer;
    private Color __initialColor;
    private void Awake()
    {
        //__renderer = GetComponent<Renderer>();
        //__initialColor = __renderer.material.color;
        ButtonToPress.enabled = false;
    }
    public override void Select() 
    {
        //__renderer.material.color = __changedColor;
        base.Select();
        ButtonToPress.enabled = true;
    }
    public override void Interact()
    {
        base.Interact();
        ButtonToPress.enabled = false;
    }
    public override void Deselect()
    {
        //__renderer.material.color = __initialColor;
        base.Deselect();
        ButtonToPress.enabled = false;
    }
}