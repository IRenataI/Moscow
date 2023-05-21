using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(DroneController))]
public class DroneAudio : MonoBehaviour
{
    private AudioSource __audioSource;
    private Rigidbody __rigidBody;
    private DroneController __controller;
    void Awake()
    {
        __audioSource = GetComponent<AudioSource>();
        __audioSource.playOnAwake = false;
        __audioSource.loop = true;

        __rigidBody = GetComponent<Rigidbody>();
        __controller = GetComponent<DroneController>();
    }
    private void ChangeDroneAudio(float value)
    {
        __audioSource.pitch = value;
    }
    private void StartDroneAudio()
    {
        __audioSource.Play();
    }

    void Update()
    {
        if (!__controller.IsDroneEnable)
            return;

        if (!__audioSource.isPlaying)
        {
            StartDroneAudio();
        }

        if (__rigidBody.velocity.magnitude > 0.1f)
        {
            ChangeDroneAudio(1.5f);
        }
        else
        {
            ChangeDroneAudio(1);
        }
    }
}
