using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TargetHitSoundPlayer : MonoBehaviour
{
    [SerializeField] private static AudioSource AudioPlayer;
    private void Awake()
    {
        AudioPlayer = GetComponent<AudioSource>();
        AudioPlayer.playOnAwake = false;
        Debug.Log(gameObject.name);
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
