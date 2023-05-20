using UnityEngine;

public class Subscribers : MonoBehaviour
{
    [SerializeField] private int CurrentSubscribers = 0;
    
    public void EarnSubscribers(int SubscribersToEarn)
    {
        CurrentSubscribers += SubscribersToEarn;
    }
}
