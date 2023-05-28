using UnityEngine;

public class CookingProgressCanvas : MonoBehaviour
{
    [SerializeField] private CookingTool cookingTool;
    [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        if (!playerTransform)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (!cookingTool)
            cookingTool = GetComponentInParent<CookingTool>();
    }

    private void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        Vector3 directionXZ = new Vector3(direction.x, 0f, direction.z);

        transform.rotation = Quaternion.LookRotation(-directionXZ);
    }
}