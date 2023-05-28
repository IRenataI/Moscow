using UnityEngine;

public class CuttingBoard : CookingTool
{
    [SerializeField] private int numberOfCuts = 3;

    private void Update()
    {
        if (!InCook())
            return;
    }

    private void Cut()
    {
        if (cookingProgress < 1f)
        {
            cookingProgress += 1f / numberOfCuts;
            progressBarImage.fillAmount = cookingProgress;
        }

        if (cookingProgress >= 1f)
        {
            EndCook();
        }
    }

    public override void IncreaseProgress()
    {
        Cut();
    }
}