using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    protected AudioSource __audioSource;
    protected virtual void Awake()
    {
        __audioSource = GetComponent<AudioSource>();
    }
}
