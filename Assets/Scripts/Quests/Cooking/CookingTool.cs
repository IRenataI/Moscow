using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
    Default,
    Cooking,
    Cooked
}

public class CookingTool : MonoBehaviour
{
    [SerializeField] private List<CookingIngredient> input;
    [SerializeField] private List<CookingIngredient> output;

    [SerializeField] private Transform cookingTransform;

    [SerializeField] private Canvas progressBarCanvas;
    [SerializeField] protected Image progressBarImage;
    
    private CookingIngredient cookingIngredient;
    private State state = State.Default;

    protected float cookingProgress = 0f;

    private void Start()
    {
        progressBarCanvas.gameObject.SetActive(false);
    }

    public void PlaceCookingIngredient(CookingIngredient cookingIngredient)
    {
        if (!Cooking.ContainsCookingIngredient(input, cookingIngredient) || state != State.Default)
            return;

        Cooking.TakeDownCookingIngredient();
        progressBarCanvas.gameObject.SetActive(true);
        progressBarImage.fillAmount = 0f;
        cookingIngredient.transform.position = cookingTransform.position;
        this.cookingIngredient = cookingIngredient;
        Cook();
    }

    private void Cook()
    {
        state = State.Cooking;
    }

    protected void EndCook()
    {
        state = State.Cooked;
        cookingProgress = 0f;

        CookingIngredient cookingIngredientInstance = Instantiate(GetOutput(cookingIngredient), cookingTransform.position, Quaternion.identity);
        Destroy(cookingIngredient.gameObject);
        cookingIngredient = cookingIngredientInstance;
    }

    public virtual void IncreaseProgress()
    {

    }

    private CookingIngredient GetOutput(CookingIngredient inputCookingIngredient)
    {
        if (!Cooking.ContainsCookingIngredient(input, inputCookingIngredient))
            return null;

        int outputCookingIngredientIndex = Cooking.IndexOfCookingIngredient(input, inputCookingIngredient);

        Debug.Log(outputCookingIngredientIndex);
        
        return output[outputCookingIngredientIndex];
    }

    public void TakeCookedIngredient()
    {
        if (state == State.Cooked)
        {
            Cooking.TakeCookingIngredient(cookingIngredient);
            progressBarCanvas.gameObject.SetActive(false);
            state = State.Default;
        }
    }

    public bool InCook()
    {
        return state == State.Cooking;
    }
}