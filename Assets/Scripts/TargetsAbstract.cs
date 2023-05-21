using UnityEngine;

public abstract class TargetsAbstract : MonoBehaviour
{
    public WinCondition __winCondition;
    public bool IsDestroyed { get { return __isDestroyed; } }
    protected bool __isDestroyed = false;
}
