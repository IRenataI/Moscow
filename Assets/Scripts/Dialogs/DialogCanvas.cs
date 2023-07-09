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
    public void CreateDialog(TextMeshProUGUI dialogs, Dialog dialog)
    {
        int length = 1;
        for (int i = 0; i < dialogs.text.Length; i++)
        {
            if (dialogs.text[i] == '\n')
            {
                length++;
            }
        }
        string[] stringDialogs = new string[length];
        TextMeshProUGUI __tempText = dialogs;
        string __tempStr = "";
        int z = 0;
        for (int j = 0; j < __tempText.text.Length; j++)
        {
            __tempStr += __tempText.text[j];
            if (__tempText.text[j] == '\n')
            {
                stringDialogs[z++] = __tempStr;
                //Debug.Log("string :" + stringDialogs[z - 1]);
                __tempStr = "";
            }
        }
        stringDialogs[z++] = __tempStr;

        __dialog = dialog;
        GameObject __temp;
        Button __tempButton;
        // Create texts.
        for (int i = 0; i < length; i++)
        //for (int i = 0; i < dialogs.Length; i++)
        {
            __temp = Instantiate(PrefabText);
            __temp.gameObject.name = "text " + i;
            __temp.transform.SetParent(__texts.transform);
            __temp.transform.localPosition = new Vector2(0, -200);
            __temp.transform.localScale = new Vector3(1, 1, 1);
            __temp.GetComponent<TextMeshProUGUI>().text = stringDialogs[i];
            //__temp.GetComponent<TextMeshProUGUI>().text = dialogs[i];
            __temp.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 100);
            __textsList.AddLast(__temp.GetComponent<TextMeshProUGUI>());            
        }
        // Create buttons.
        for (int i = 0; i < length; i++)
        //for (int i = 0; i < dialogs.Length; i++)
        {
            __temp = Instantiate(PrefabButton);
            __temp.gameObject.name = "Button " + i;
            __temp.transform.SetParent(__buttons.transform);
            __temp.transform.localPosition = new Vector2(0, -300);
            __temp.transform.localScale = new Vector3(1, 1, 1);
            __buttonsList.AddLast(__temp.GetComponent<Button>());
        }
        // add events on click to buttons.
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

        GameObject __acceptQuestButton = Instantiate(PrefabButton);
        GameObject __rejectQuestButton = Instantiate(PrefabButton);

        __buttonsList.ElementAt(__buttonsList.Count - 1).onClick.AddListener(() => __acceptQuestButton.SetActive(true));
        __buttonsList.ElementAt(__buttonsList.Count - 1).onClick.AddListener(() => __rejectQuestButton.SetActive(true));
        __buttonsList.ElementAt(__buttonsList.Count - 1).onClick.AddListener(() => __buttonsList.ElementAt(__buttonsList.Count - 1).gameObject.SetActive(false));
        
        __acceptQuestButton.gameObject.SetActive(false);
        __acceptQuestButton.gameObject.name = "Button " + "reject";
        __acceptQuestButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Согласиться";
        __acceptQuestButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 17;
        __acceptQuestButton.transform.SetParent(__buttons.transform);
        __acceptQuestButton.transform.localPosition = new Vector2(300, -100);
        __acceptQuestButton.transform.localScale = new Vector3(2, 2, 2);


        __rejectQuestButton.gameObject.SetActive(false);
        __rejectQuestButton.gameObject.name = "Button " + "reject";
        __rejectQuestButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Отказаться";
        __rejectQuestButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 17;
        __rejectQuestButton.transform.SetParent(__buttons.transform);
        __rejectQuestButton.transform.localPosition = new Vector2(-300, -100);
        __rejectQuestButton.transform.localScale = new Vector3(2, 2, 2);

        __acceptQuestButton.GetComponent<Button>().onClick.AddListener(() => __dialog.DisableDialogCanvas());
        __acceptQuestButton.GetComponent<Button>().onClick.AddListener(() => __dialog.OnEndDialog?.Invoke());
        __acceptQuestButton.GetComponent<Button>().onClick.AddListener(() => DeleteDialog());


        __rejectQuestButton.GetComponent<Button>().onClick.AddListener(() => __dialog.DisableDialogCanvas());
        __rejectQuestButton.GetComponent<Button>().onClick.AddListener(() => DeleteDialog());

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
    public void CreateDialogWithoutChoices(TextMeshProUGUI dialogs, Dialog dialog)
    {
        int length = 1;
        for (int i = 0; i < dialogs.text.Length; i++)
        {
            if (dialogs.text[i] == '\n')
            {
                length++;
            }
        }
        string[] stringDialogs = new string[length];
        TextMeshProUGUI __tempText = dialogs;
        string __tempStr = "";
        int z = 0;
        for (int j = 0; j < __tempText.text.Length; j++)
        {
            __tempStr += __tempText.text[j];
            if (__tempText.text[j] == '\n')
            {
                stringDialogs[z++] = __tempStr;
                //Debug.Log("string :" + stringDialogs[z - 1]);
                __tempStr = "";
            }
        }
        stringDialogs[z++] = __tempStr;

        __dialog = dialog;
        GameObject __temp;
        Button __tempButton;
        // Create texts.
        for (int i = 0; i < length; i++)
        //for (int i = 0; i < dialogs.Length; i++)
        {
            __temp = Instantiate(PrefabText);
            __temp.gameObject.name = "text " + i;
            __temp.transform.SetParent(__texts.transform);
            __temp.transform.localPosition = new Vector2(0, -200);
            __temp.transform.localScale = new Vector3(1, 1, 1);
            __temp.GetComponent<TextMeshProUGUI>().text = stringDialogs[i];
            //__temp.GetComponent<TextMeshProUGUI>().text = dialogs[i];
            __temp.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 100);
            __textsList.AddLast(__temp.GetComponent<TextMeshProUGUI>());
        }
        // Create buttons.
        for (int i = 0; i < length; i++)
        //for (int i = 0; i < dialogs.Length; i++)
        {
            __temp = Instantiate(PrefabButton);
            __temp.gameObject.name = "Button " + i;
            __temp.transform.SetParent(__buttons.transform);
            __temp.transform.localPosition = new Vector2(0, -300);
            __temp.transform.localScale = new Vector3(1, 1, 1);
            __buttonsList.AddLast(__temp.GetComponent<Button>());
        }
        // add events on click to buttons.
        for (int i = 0; i < __buttonsList.Count - 1; i++)
        {
            __tempButton = __buttonsList.ElementAt(i);
            int oldI = i;
            int newI = i + 1;
            __tempButton.onClick.AddListener(() => __textsList.ElementAt(oldI).gameObject.SetActive(false));
            __tempButton.onClick.AddListener(() => __textsList.ElementAt(newI).gameObject.SetActive(true));

            __tempButton.onClick.AddListener(() => __buttonsList.ElementAt(newI).gameObject.SetActive(true));
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