using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 1f;
    [SerializeField] private float lerpRate = 1f;

    private bool isAnimationStarted;
    private Vector3 baseScale;

    private void Update()
    {
        if (!isAnimationStarted)
            return;

        transform.localScale = Vector3.Lerp(transform.localScale, scaleFactor * baseScale, lerpRate * Time.deltaTime);
    }

    public void StartAnimation()
    {
        Debug.Log("[ScaleAnimation] Animation started on " + gameObject.name);
        isAnimationStarted = true;
        baseScale = transform.localScale;
    }

    public void StopAnimation()
    {
        Debug.Log("[ScaleAnimation] Animation stoppedd on " + gameObject.name);
        isAnimationStarted = false;
        transform.localScale = baseScale;
    }
}