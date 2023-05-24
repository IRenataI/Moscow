using UnityEngine;

public class Subscribers : MonoBehaviour
{
    private static int CurrentSubscribers = 0;
    
    public static void EarnSubscribers(int SubscribersToEarn)
    {
        CurrentSubscribers += SubscribersToEarn;
    }
}
