using UnityEngine;
using TMPro;

public class Subscribers : MonoBehaviour
{
    public TextMeshProUGUI subscriberstext;

    private static int CurrentSubscribers = 1000;

    private void Update()
    {
        subscriberstext.text = CurrentSubscribers.ToString() + " Подписчиков";
    }
    public static int GetSubscribersAmount { get { return CurrentSubscribers; } }
    public static void EarnSubscribers(int SubscribersToEarn)
    {
        CurrentSubscribers += SubscribersToEarn;
    }
}
