using UnityEngine;

public class EnterToPlacesv2 : MonoBehaviour
{
    [SerializeField] private Transform[] PlacesPositions;
    [SerializeField] private Transform[] ReturnPositions;
    private FirstPersonMovement __player;
    private bool __IsEntering = false;
    private Transform __desiredPosition;
    private void Awake()
    {
        __player = FindObjectOfType<FirstPersonMovement>();
    }
    public void EnterToLeninPlace()
    {
        __desiredPosition = PlacesPositions[0];
        __IsEntering = true;
        BlackScreenUI.EnableBlackScreen();
    }
    public void LeaveLeninPlace()
    {
        __desiredPosition = ReturnPositions[0];
        __IsEntering = true;
        BlackScreenUI.EnableBlackScreen();
    }
    private void FixedUpdate()
    {
        if (!__IsEntering)
            return;

        if (BlackScreenUI.GetBlackScreenAlpha() > 0.99f)
        {
            __player.transform.position = __desiredPosition.position;
            __IsEntering = false;
            BlackScreenUI.DisableBlackScreen();
        }
    }
}