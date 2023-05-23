using UnityEngine;

public class Money : MonoBehaviour
{
    private static int CurrentMoney = 1000;

    public static bool WasteMoney(int moneyToWaste)
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
    public static void EarnMoney(int moneyToEarn)
    {
        CurrentMoney += moneyToEarn;
    }
}
