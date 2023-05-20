using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int CurrentMoney = 1000;

    public bool WasteMoney(int moneyToWaste)
    {
        if (CurrentMoney - moneyToWaste >= 0)
        {
            CurrentMoney -= moneyToWaste;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void EarnMoney(int moneyToEarn)
    {
        CurrentMoney += moneyToEarn;
    }
}
