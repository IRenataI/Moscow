using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask cookingLayerMask;
    [SerializeField] private float flyingHeight;

    private CookingIngredient mouseFollowCookingIngredient;
    private CookingTool currentCookingTool;
    private Plate currentPlate;

    private static Cooking instance;
    private static bool isEnable;

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
            currentPlate = hitInfo.transform.GetComponent<Plate>();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Interact();
    }

    private void OnEnable()
    {
        isEnable = true;
    }

    private void OnDisable()
    {
        isEnable = false;
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
        else if (currentPlate)
        {
            currentPlate.AddIngredient(mouseFollowCookingIngredient);
        }
    }

    public static void TakeCookingIngredient(CookingIngredient cookingIngredient)
    {
        if (!isEnable)
            return;

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
        if (cookingIngredientList == null)
            return false;

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