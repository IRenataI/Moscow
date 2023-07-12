using UnityEngine;
using UnityEngine.Events;

public class CheckMoney : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition;

    public UnityEvent OnBuy;

    public void Buy(int moneyAmount)
    {
        if (Money.GetInstance.WasteMoney(moneyAmount))
        {
            winCondition.IncreaseHittedTargets();
            OnBuy?.Invoke();
        }
    }
}