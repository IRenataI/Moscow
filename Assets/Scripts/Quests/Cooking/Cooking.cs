using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask cookingLayerMask;
    [SerializeField] private float flyingHeight;

    [SerializeField] private List<CookingIngredient> recipe;
    private List<CookingIngredient> progress;

    private CookingIngredient mouseFollowCookingIngredient;
    private CookingTool currentCookingTool;

    private static Cooking instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, cookingLayerMask))
        {
            if (mouseFollowCookingIngredient)
                Drag(hitInfo.point);

            currentCookingTool = hitInfo.transform.GetComponent<CookingTool>();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Interact();
    }

    private void Drag(Vector3 position)
    {
        mouseFollowCookingIngredient.transform.position = position + flyingHeight * Vector3.up;
    }

    private void Interact()
    {
        if (currentCookingTool)
        {
            if (mouseFollowCookingIngredient)
                currentCookingTool.PlaceCookingIngredient(mouseFollowCookingIngredient);
            else if (currentCookingTool.InCook())
                currentCookingTool.IncreaseProgress();
            else
                currentCookingTool.TakeCookedIngredient();
        }
    }

    private bool AddIngredient(CookingIngredient cookingIngredient)
    {
        if (!ContainsCookingIngredient(recipe, cookingIngredient) || ContainsCookingIngredient(progress, cookingIngredient))
            return false;

        progress.Add(cookingIngredient);
        IncreaseProgress();

        return true;
    }

    private void IncreaseProgress()
    {
        winCondition.IncreaseHittedTargets();
    }

    public static void TakeCookingIngredient(CookingIngredient cookingIngredient)
    {
        if (instance.mouseFollowCookingIngredient)
            Destroy(instance.mouseFollowCookingIngredient.gameObject);

        instance.mouseFollowCookingIngredient = cookingIngredient;
    }

    public static void TakeDownCookingIngredient()
    {
        instance.mouseFollowCookingIngredient = null;
    }

    public static bool ContainsCookingIngredient(List<CookingIngredient> cookingIngredientList, CookingIngredient cookingIngredient)
    {
        foreach (CookingIngredient ci in cookingIngredientList)
        {
            if (ci.Id == cookingIngredient.Id)
                return true;
        }

        return false;
    }

    public static int IndexOfCookingIngredient(List<CookingIngredient> cookingIngredientList, CookingIngredient cookingIngredient)
    {
        Debug.Log(cookingIngredientList.Count);

        for (int index = 0; index < cookingIngredientList.Count; index++)
        {
            Debug.Log(index + " - " + (cookingIngredientList[index].Id == cookingIngredient.Id));
            Debug.LogWarning(cookingIngredientList[index].Id + " == " + cookingIngredient.Id);
            
            if (cookingIngredientList[index].Id == cookingIngredient.Id)
                return index;
        }

        return -1;
    }
}