using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CookingIngredientContainer : MonoBehaviour
{
    [SerializeField] private CookingIngredient cookingIngredient;

    private void OnMouseDown()
    {
        CookingIngredient cookingIngredientInstance = Instantiate(cookingIngredient);
        Cooking.TakeCookingIngredient(cookingIngredientInstance);
    }
}