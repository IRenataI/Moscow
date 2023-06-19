using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Activator : MonoBehaviour
{
    public KeyCode KeyToPress;
    public WinCondition __winCondition;
    public TextMeshProUGUI Counter;
    private GameObject __collidedGameObject;
    private Color __initialColor;
    private RawImage __rawImage;
    private AudioSource __audioSource;
    private void Awake()
    {
        __rawImage = GetComponent<RawImage>();
        __initialColor = new Color(0, 200f / 255f, 0);// __renderer.material.color;
        __rawImage.color = __initialColor;
        __audioSource = GetComponent<AudioSource>();
        __audioSource.playOnAwake = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            __rawImage.color = __initialColor + new Color(0, 55f / 255f, 0);
            if (__collidedGameObject)
            {
                Function(__collidedGameObject);
            }
            __audioSource.Play();
        }
        else if (Input.GetKeyUp(KeyToPress))
        {
            __rawImage.color = __initialColor;
        }

        Debug.DrawLine(temp1, temp2, Color.red);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Exit: " + __collidedGameObject);

        GuitarTarget __collided = collision.gameObject.GetComponent<GuitarTarget>();
        if (__collided && !__collided.IsDestroyed)
        {
            __collidedGameObject = collision.gameObject;

            Counter.text = " " + __winCondition.GetHittedTargetsNumber;
            //Debug.Log("Destroyed");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit: " + __collidedGameObject);
        __collidedGameObject = null;
    }

    private Vector3 temp1 = Vector3.zero, temp2 = Vector3.zero;
    private void Function(GameObject collidedGameObject)
    {
        collidedGameObject.GetComponent<GuitarTarget>().HideObject(1);

        if (temp1 == Vector3.zero)
            temp1 = collidedGameObject.transform.position;
        if (temp2 == Vector3.zero)
            temp2 = transform.position;

        __winCondition.IncreaseHittedTargets();

        //__isColliderGuitarTarget = false;
        __collidedGameObject = null;
    }
}

//collidedGameObject.GetComponent<GuitarTarget>().HideObject( Mathf.Clamp( 1 - ((collidedGameObject.transform.position - transform.position) / 10).magnitude,0,1f));
// Debug.Log((collidedGameObject.transform.localPosition - transform.localPosition).magnitude);

/*
if (__winCondition.GetObjectsToHit - __winCondition.GetHittedTargetsNumber == 1)
{
    __winCondition.__quest.EventOnEnd?.Invoke();
    //endGameDialog.EnableDialogCanvas();
}
*/

//private bool __isColliderGuitarTarget = false;

//public Dialog endGameDialog;