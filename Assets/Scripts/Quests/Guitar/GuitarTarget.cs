using UnityEngine;
using UnityEngine.UI;

public class GuitarTarget : TargetsAbstract
{
    public bool IsDeactivated = false;
    public float Velocity = 0.5f;
    private BoxCollider2D __boxCollider2D;
    private RawImage _image;
    private void Awake()
    {
        __boxCollider2D = GetComponent<BoxCollider2D>();
        _image = GetComponent<RawImage>();
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Velocity, 
            transform.position.z);
    }
    public void HideObject()
    {
        __isDestroyed = true;
        __boxCollider2D.enabled = false;
        _image.enabled = false;
    }
}
