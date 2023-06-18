using UnityEngine;
using UnityEngine.UI;

public class GuitarTarget : TargetsAbstract
{
    public static float Velocity = 2f; //default 1.5f
    public bool IsDeactivated = false;
    public float _delayBetweenIncreaseVelocity = 5f;
    private float __delay;
    private BoxCollider2D __boxCollider2D;
    private RawImage _image;
    private float __accuracy = 0f;
    public float GetAccuracy { get { return __accuracy; } }
    private void Awake()
    {
        __boxCollider2D = GetComponent<BoxCollider2D>();
        _image = GetComponent<RawImage>();
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, 
            transform.position.y - Velocity, 
            transform.position.z);

        if (__delay > _delayBetweenIncreaseVelocity)
        {
            Velocity = Mathf.Clamp(Velocity + 0.01f,0,10);
            __delay = 0;
        }
        __delay += Time.fixedDeltaTime;
    }
    public void HideObject(float accuracy)
    {
        __accuracy = accuracy;
        __isDestroyed = true;
        __boxCollider2D.enabled = false;
        _image.enabled = false;
    }
    public void ResetVelocity()
    {
        Velocity = 1.5f;
    }
}
