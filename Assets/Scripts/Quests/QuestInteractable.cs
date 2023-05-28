using UnityEngine;

public class QuestInteractable : Interactable
{
    private ButtonToPressUI __buttonToPress;
    private Canvas __buttonToPressCanvas;
    private void Awake()
    {
        __buttonToPress = FindObjectOfType<ButtonToPressUI>();
        __buttonToPressCanvas = __buttonToPress.GetComponent<Canvas>();
        __buttonToPressCanvas.enabled = false;
    }
    public override void Select() 
    {
        base.Select();
        __buttonToPressCanvas.enabled = true;
    }
    public override void Interact()
    {
        base.Interact();
        __buttonToPressCanvas.enabled = false;
    }
    public override void Deselect()
    {
        base.Deselect();
        __buttonToPressCanvas.enabled = false;
    }
}