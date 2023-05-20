using UnityEngine;

public class GameInputManager : MonoBehaviour
{
    private static bool __isTabPressed;
    private static bool __isSpacePressed;
    void Update()
    {
        __isTabPressed = Input.GetKey(KeyCode.Tab);
        __isSpacePressed = Input.GetKey(KeyCode.Space);
        //Debug.Log(__isSpacePressed);
    }
    public static bool IsSpacePressed()
    {
        return __isSpacePressed;
    }
    public static bool IsTabPressed()
    {
        return __isTabPressed;
    }
}
