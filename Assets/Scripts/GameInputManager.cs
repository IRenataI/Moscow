using UnityEngine;

public class GameInputManager : MonoBehaviour
{
    private static bool __isTabPressed;
    private static bool __isSpacePressed;
    private static bool __isPressedArrowUp, __isPressedArrowDown, __isPressedArrowLeft, 
        __isPressedArrowRight;
    void Update()
    {
        __isTabPressed = Input.GetKey(KeyCode.Tab);
        __isSpacePressed = Input.GetKey(KeyCode.Space);

        __isPressedArrowUp = Input.GetKeyDown(KeyCode.UpArrow);
        __isPressedArrowDown = Input.GetKeyDown(KeyCode.DownArrow);
        __isPressedArrowLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        __isPressedArrowRight = Input.GetKeyDown(KeyCode.RightArrow);
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
    public static bool IsPressedArrow(KeyCode code)
    {
        //Debug.Log(code);
        switch (code)
        {
            case KeyCode.UpArrow:
                return __isPressedArrowUp;
            case KeyCode.DownArrow:
                return __isPressedArrowDown;
            case KeyCode.LeftArrow:
                return __isPressedArrowLeft;
            case KeyCode.RightArrow:
                return __isPressedArrowRight;
            default:
                return false;
        }
    }
}
