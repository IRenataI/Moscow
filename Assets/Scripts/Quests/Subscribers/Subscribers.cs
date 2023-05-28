using UnityEngine;

public class Subscribers : MonoBehaviour
{
    private static int CurrentSubscribers = 100;
    public static int GetSubscribersAmount { get { return CurrentSubscribers; } }
    public static void EarnSubscribers(int SubscribersToEarn)
    {
        CurrentSubscribers += SubscribersToEarn;
    }
}
