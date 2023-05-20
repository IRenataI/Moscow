using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnSelect;
    public UnityEvent OnInteract;
    public UnityEvent OnDeselect;

    public virtual void Select() => OnSelect?.Invoke();
    public virtual void Interact() => OnInteract?.Invoke();
    public virtual void Deselect() => OnDeselect?.Invoke();
}