using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Activator : MonoBehaviour
{
    public KeyCode KeyToPress;
    public WinCondition __winCondition;
    public TextMeshProUGUI Counter;
    private bool __isColliderGuitarTarget = false;
    private GameObject __collidedGameObject;
    private Color __initialColor;
    private RawImage __rawImage;
    private void Awake()
    {
        __rawImage = GetComponent<RawImage>();
        __initialColor = new Color(0, 200f / 255f, 0);// __renderer.material.color;
        __rawImage.color = __initialColor;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            __rawImage.color = __initialColor + new Color(0, 55f / 255f, 0);
            if (__isColliderGuitarTarget)
            {
                Function(__collidedGameObject);
            }
        }
        else if (Input.GetKeyUp(KeyToPress))
        {
            __rawImage.color = __initialColor;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GuitarTarget __collided = collision.gameObject.GetComponent<GuitarTarget>();
        if (__collided && !__collided.IsDestroyed)
        {
            __isColliderGuitarTarget = true;
            __collidedGameObject = collision.gameObject;

            Counter.text = " " + __winCondition.GetHittedTargetsNumber;
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
