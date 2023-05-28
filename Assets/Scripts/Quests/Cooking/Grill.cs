using UnityEngine;

public class Grill : CookingTool
{
    [SerializeField] private float cookTime = 3f;

    private void Update()
    {
        if (!InCook())
            return;

        if (cookingProgress < 1f)
        {
            cookingProgress += Time.deltaTime / cookTime;
            progressBarImage.fillAmount = cookingProgress;
        }

        if (cookingProgress >= 1f)
        {
            EndCook();
        }
    }
}