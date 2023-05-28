using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class Plate : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition;
    [SerializeField] private List<CookingIngredient> recipe;
    private List<CookingIngredient> progress = new();

    public bool AddIngredient(CookingIngredient cookingIngredient)
    {
        if (!Cooking.ContainsCookingIngredient(recipe, cookingIngredient) || Cooking.ContainsCookingIngredient(progress, cookingIngredient))
            return false;

        Cooking.TakeDownCookingIngredient();
        progress.Add(cookingIngredient);
        cookingIngredient.transform.position = transform.position;
        IncreaseProgress();

        return true;
    }

    private void IncreaseProgress()
    {
        winCondition.IncreaseHittedTargets();
    }
}