public class QuestInteractable : Interactable
{
    private void Awake()
    {
        OnInteract.AddListener(() => GetComponent<Dialog>()?.EnableDialogCanvas());
    }
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