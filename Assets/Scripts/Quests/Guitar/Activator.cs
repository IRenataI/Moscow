using UnityEngine;
using UnityEngine.UI;

public class Activator : MonoBehaviour
{
    public KeyCode KeyToPress;
    public WinCondition __winCondition;
    private bool __isColliderGuitarTarget = false;
    private GameObject __collidedGameObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyToPress) && __isColliderGuitarTarget)
        {
            Function(__collidedGameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GuitarTarget __collided = collision.gameObject.GetComponent<GuitarTarget>();
        if (__collided && !__collided.IsDestroyed)
        {
            __isColliderGuitarTarget = true;
            __collidedGameObject = collision.gameObject;
            //Debug.Log("Destroyed");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        __isColliderGuitarTarget = false;
        __collidedGameObject = null;
    }
    private void Function(GameObject gameObject)
    {
        gameObject.GetComponent<GuitarTarget>().HideObject();
        __winCondition.IncreaseHittedTargets();

        __isColliderGuitarTarget = false;
        __collidedGameObject = null;
    }
}
