using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource Audio;
    private void Awake()
    {
        Audio.playOnAwake = false;
    }
    public void Play()
    {
        Audio.Play();
    }
    public void Stop()
    {
        Audio.Stop();
    }
}
