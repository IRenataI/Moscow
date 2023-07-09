using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Moneytext;
    private int CurrentMoney = 1000;
    private AudioSource __soundPlayer;
    private static Money __instance;
    public static Money GetInstance => __instance;
    public int GetCurrentMoney { get { return CurrentMoney; } }

    private void Awake()
    {
        if (!__instance)
        {
            __instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        __soundPlayer = GetComponent<AudioSource>();
        __soundPlayer.playOnAwake = false;
    }
    private void Update()
    {
        Moneytext.text = CurrentMoney.ToString();
    }
    public bool WasteMoney(int moneyToWaste)
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
    public void WasteMoney2(int moneyToWaste)
    {
        if (CurrentMoney - moneyToWaste >= 0)
        {
            __soundPlayer.Play();
            CurrentMoney -= moneyToWaste;
        }
    }
    public void EarnMoney(int moneyToEarn)
    {
        CurrentMoney += moneyToEarn;
    }
}
