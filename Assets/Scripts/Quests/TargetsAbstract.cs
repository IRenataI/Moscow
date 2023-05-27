using UnityEngine;

public abstract class TargetsAbstract : MonoBehaviour
{
    protected WinCondition __winCondition;
    public bool IsDestroyed { get { return __isDestroyed; } }
    protected bool __isDestroyed = false;
    private Vector3 __initialPosition;
    private Quaternion __initialRotation;
    private void Awake()
    {
        __initialPosition = transform.position;
    }
    public void SetWinCodition(WinCondition condition)
    {
        __winCondition = condition;
    }
    public void ResetDestroyedCondition()
    {
        __isDestroyed = false;
        transform.position = __initialPosition;
        transform.rotation = __initialRotation;
        Debug.Log("targets resseted");
    }
}
