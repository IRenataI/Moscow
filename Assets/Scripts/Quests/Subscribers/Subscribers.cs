using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Subscribers : MonoBehaviour
{
    public TextMeshProUGUI subscriberstext;

    private static int CurrentSubscribers = 1000;
    private static AudioSource __sound;
    private void Awake()
    {
        __sound = GetComponent<AudioSource>();
        __sound.playOnAwake = false;
    }
    private void Update()
    {
        subscriberstext.text = CurrentSubscribers.ToString() + " Подписчиков";
    }
    public static int GetSubscribersAmount { get { return CurrentSubscribers; } }
    public static void EarnSubscribers(int SubscribersToEarn)
    {
        CurrentSubscribers += SubscribersToEarn;
        __sound.Play();
    }
}
