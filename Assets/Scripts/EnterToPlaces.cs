using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnterToPlaces : MonoBehaviour
{
    public Transform Player;
    public GameObject BlackScreen;

    IEnumerator EGoToFastFood()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 NewPosition = new Vector3(-227.582f, -23.797f, 60.246f);
        Player.transform.position = NewPosition;
        yield return new WaitForSeconds(2f);
        BlackScreen.SetActive(false);
    }

    IEnumerator EGoToLenin()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 NewPosition = new Vector3(-225.301f, -24.398f, 93.526f);
        Player.transform.position = NewPosition;
        yield return new WaitForSeconds(2f);
        BlackScreen.SetActive(false);
    }

    IEnumerator EGoToRestaurant()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 NewPosition = new Vector3(-230.541f, -23.697f, 75.272f);
        Player.transform.position = NewPosition;
        yield return new WaitForSeconds(2f);
        BlackScreen.SetActive(false);
    }

    public void GoToRestaurant()
    {
        StartCoroutine(EGoToRestaurant());
    }
    public void GoToFastFood()
    {
        StartCoroutine(EGoToFastFood());
    }
    public void GoToLenin()
    {
        StartCoroutine(EGoToLenin());
    }

    public void UnlockCoursore()
    {
        GameSystem.ChangeCursorMode(CursorLockMode.Locked);
    }
    public void LockCoursore()
    {
        GameSystem.ChangeCursorMode(CursorLockMode.Confined);
    }

}
