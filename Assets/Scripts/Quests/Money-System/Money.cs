using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Money : MonoBehaviour
{
    public TextMeshProUGUI Moneytext;
    private static int CurrentMoney = 1000;
    public static int GetCurrentMoney { get { return CurrentMoney; } }
    private static AudioSource __soundPlayer;
    private void Awake()
    {
        __soundPlayer = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Moneytext.text = CurrentMoney.ToString();
    }
    public static bool WasteMoney(int moneyToWaste)
    {
        if (CurrentMoney - moneyToWaste >= 0)
        {
            __soundPlayer.Play();
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
