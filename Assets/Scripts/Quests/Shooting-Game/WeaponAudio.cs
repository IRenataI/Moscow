using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponAudio : MonoBehaviour
{
    private AudioSource ShotSound;
    private void Awake()
    {
        ShotSound = GetComponent<AudioSource>();
        ShotSound.playOnAwake = false;
    }
    public void PlayShotSound()
    {
        ShotSound.Play();
    }
}
