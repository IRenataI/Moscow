using TMPro;
using UnityEngine;

public class SubscribersUI : MonoBehaviour
{
    private TextMeshProUGUI __text;
    private void Awake()
    {
        __text = GetComponent<TextMeshProUGUI>();
        __text.text = "Спасибо за прохождение демо. У вас " + Subscribers.GetSubscribersAmount + " подписчиков.  Попробуйте другие варианты прохождения.";

    }
}
