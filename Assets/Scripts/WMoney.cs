using UnityEngine;
using UnityEngine.Events;

public class WMoney : MonoBehaviour
{
    public UnityEvent OnWaste;

    public void Waste(int value)
    {
        if (Money.WasteMoney(value))
        {
            OnWaste?.Invoke();
            Destroy(this);
        }
    }
}