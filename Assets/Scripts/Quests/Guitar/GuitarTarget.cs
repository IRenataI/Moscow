using UnityEngine;
using UnityEngine.UI;

public class GuitarTarget : TargetsAbstract
{     
    public float Velocity = 0.5f;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Velocity, 
            transform.position.z);
    }
    public void HideObject()
    {
        __isDestroyed = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<RawImage>().enabled = false;
    }
}
