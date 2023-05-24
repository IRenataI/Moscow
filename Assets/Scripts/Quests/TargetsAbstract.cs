using UnityEngine;

public abstract class TargetsAbstract : MonoBehaviour
{
    protected WinCondition __winCondition;
    public bool IsDestroyed { get { return __isDestroyed; } }
    protected bool __isDestroyed = false;
    public void SetWinCodition(WinCondition condition)
    {
        __winCondition = condition;
    }
}
