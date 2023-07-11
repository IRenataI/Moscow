using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(DroneController))]
public class DroneAudio : AudioPlayer
{
    private Rigidbody __rigidBody;
    private DroneController __controller;
    protected override void Awake()
    {
        base.Awake();
        __audioSource.playOnAwake = false;
        __audioSource.loop = true;

        __rigidBody = GetComponent<Rigidbody>();
        __controller = GetComponent<DroneController>();
    }
    private void ChangeDroneAudio(float value)
    {
        if (value > __audioSource.pitch)
            __audioSource.pitch = Mathf.Clamp( __audioSource.pitch + 0.01f, 0, value);
        else if(value < __audioSource.pitch)
            __audioSource.pitch = Mathf.Clamp(__audioSource.pitch - 0.01f, value, 10);
    }
    private void StartDroneAudio()
    {
        __audioSource.Play();
    }

    void Update()
    {
        if (!__controller.IsDroneEnable)
        {
            __audioSource.Stop();
            return;
        }

        if (!__audioSource.isPlaying)
        {
            StartDroneAudio();
            Debug.Log("Drone audio is playing");
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
