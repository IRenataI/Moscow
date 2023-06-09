using UnityEngine;

public class QuestCompletionSound : MonoBehaviour
{
    [SerializeField] private static AudioSource AudioPlayer;
    private void Awake()
    {
        AudioPlayer = GetComponent<AudioSource>();
        AudioPlayer.playOnAwake = false;
    }
    public static void Play()
    {
        AudioPlayer.Play();
    }
    public static void Stop()
    {
        AudioPlayer.Stop();
    }
}
