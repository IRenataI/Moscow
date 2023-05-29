using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI Moneytext;
    public static int CurrentMoney = 1000;

    private void Update()
    {
        Moneytext.text= CurrentMoney.ToString();
    }
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
