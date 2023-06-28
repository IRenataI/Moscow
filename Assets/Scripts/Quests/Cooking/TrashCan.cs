public class TrashCan : CookingTool
{
    private void Update()
    {
        if (InCook)
            Delete();
    }

    private void Delete()
    {
        InterruptCook();
        Destroy(cookingIngredient);
    }
}