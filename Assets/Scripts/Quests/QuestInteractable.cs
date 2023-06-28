public class QuestInteractable : Interactable
{
    public override void Select() 
    {
        base.Select();
        ButtonToPressUI.EnableCanvas();
    }
    public override void Interact()
    {
        base.Interact();
        ButtonToPressUI.DisableCanvas();
    }
    public override void Deselect()
    {
        base.Deselect();
        ButtonToPressUI.DisableCanvas();
    }
}