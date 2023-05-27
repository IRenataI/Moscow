using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogCanvas : MonoBehaviour
{
    public UnityAction EventOnEndOfDialog;
    public GameObject PrefabText;
    public GameObject PrefabButton;
    private GameObject __buttons;
    private GameObject __texts;
    private LinkedList<Button> __buttonsList = new LinkedList<Button>();
    private LinkedList<TextMeshProUGUI> __textsList = new LinkedList<TextMeshProUGUI>();
    private Dialog __dialog;
    private void Awake()
    {
        __buttons = transform.GetChild(0).gameObject;
        __texts = transform.GetChild(1).gameObject;
    }
    public void CreateDialog(string[] dialogs, Dialog dialog)
    {
        __dialog = dialog;
        GameObject __temp;
        Button __tempButton;
        for (int i = 0; i < dialogs.Length; i++)
        {
            __temp = Instantiate(PrefabText);
            __temp.gameObject.name = "text " + i;
            __temp.transform.SetParent(__texts.transform);
            __temp.transform.localPosition = new Vector2(0, -200);
            __temp.transform.localScale = new Vector3(1, 1, 1);
            __temp.GetComponent<TextMeshProUGUI>().text = dialogs[i];
            __textsList.AddLast(__temp.GetComponent<TextMeshProUGUI>());            
        }
        for (int i = 0; i < dialogs.Length; i++)
        {
            __temp = Instantiate(PrefabButton);
            __temp.gameObject.name = "Button " + i;
            __temp.transform.SetParent(__buttons.transform);
            __temp.transform.localPosition = new Vector2(0, -300 - i * 50);
            __temp.transform.localScale = new Vector3(1, 1, 1);
            __buttonsList.AddLast(__temp.GetComponent<Button>());
        }
        for (int i = 0; i < __buttonsList.Count - 1; i++)
        {
            __tempButton = __buttonsList.ElementAt(i);
            int oldI = i;
            int newI = i + 1;
            __tempButton.onClick.AddListener(() => __textsList.ElementAt(oldI).gameObject.SetActive(false) );
            __tempButton.onClick.AddListener(() => __textsList.ElementAt(newI).gameObject.SetActive(true) );

            __tempButton.onClick.AddListener(() => __buttonsList.ElementAt(newI).gameObject.SetActive(true) );
            __tempButton.onClick.AddListener(() => __buttonsList.ElementAt(oldI).gameObject.SetActive(false));
            //Debug.Log("ElementAt " + newI + ": " + __buttonsList.ElementAt(newI).gameObject.name);
            //Debug.Log("ElementAt " + oldI + ": " + __buttonsList.ElementAt(oldI).gameObject.name);
        }
        __buttonsList.ElementAt(__buttonsList.Count - 1).onClick.AddListener(() => __dialog.DisableDialogCanvas());
        __buttonsList.ElementAt(__buttonsList.Count - 1).onClick.AddListener(() => DeleteDialog());

        for (int i = 1; i < __buttonsList.Count; i++)
        {
            __buttonsList.ElementAt(i).gameObject.SetActive(false);
        }
        for (int i = 1; i < __textsList.Count; i++)
        {
            __textsList.ElementAt(i).gameObject.SetActive(false);
        }

        //Debug.Log("dialogs.Length " + dialogs.Length + "\n __buttonsList.Count" + __buttonsList.Count + "\n __textsList.Count" + __textsList.Count);
    }
    public void DeleteDialog()
    {
        foreach (Transform child in __buttons.transform)
        {
            Destroy(child?.GetComponent<TextMeshProUGUI>());
            Destroy(child?.GetComponent<Image>());
            Destroy(child.gameObject);
        }
        foreach (Transform child in __texts.transform)
        {
            Destroy(child?.GetComponent<TextMeshProUGUI>());
            Destroy(child?.GetComponent<Image>());
            Destroy(child.gameObject);
        }
        __buttonsList.Clear();
        __textsList.Clear();
    }
}
//int oldI, newI;
/*
__tempButton = __buttonsList.ElementAt(0);
__tempButton.onClick.AddListener(() => __textsList.ElementAt(1).gameObject.SetActive(false));
__tempButton.onClick.AddListener(() => __textsList.ElementAt(0).gameObject.SetActive(true));

__tempButton.onClick.AddListener(() => __buttonsList.ElementAt(1).gameObject.SetActive(true));
__tempButton.onClick.AddListener(() => __buttonsList.ElementAt(0).gameObject.SetActive(false));

__tempButton = __buttonsList.ElementAt(1);
__tempButton.onClick.AddListener(() => __textsList.ElementAt(2).gameObject.SetActive(false));
__tempButton.onClick.AddListener(() => __textsList.ElementAt(1).gameObject.SetActive(true));

__tempButton.onClick.AddListener(() => __buttonsList.ElementAt(2).gameObject.SetActive(true));
__tempButton.onClick.AddListener(() => __buttonsList.ElementAt(1).gameObject.SetActive(false));
*/

/*
            if (i == __buttonsList.Count - 2)
            {
                __tempButton.onClick.AddListener(() => __dialog.DisableDialogCanvas());
                __tempButton.onClick.AddListener(() => DeleteDialog());
            }
            else
            {
                __tempButton.onClick.AddListener(() => __buttonsList.ElementAt(oldI).gameObject.SetActive(false));
            }
            */