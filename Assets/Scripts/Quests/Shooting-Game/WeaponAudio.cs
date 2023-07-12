using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponAudio : AudioPlayer
{
    protected override void Awake()
    {
        base.Awake();
        __audioSource.playOnAwake = false;
    }
    public void PlayShotSound()
    {
        __audioSource.Play();
    }
}
