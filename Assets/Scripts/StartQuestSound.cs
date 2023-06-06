using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StartQuestSound : MonoBehaviour
{
    private static AudioSource __sound;
    private void Awake()
    {
        __sound = GetComponent<AudioSource>();
    }
    public static void Play()
    {
        __sound.Play();
    }
    public static void Stop()
    {

    }
}
