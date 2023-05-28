using TMPro;
using UnityEngine;

public class SubscribersUI : MonoBehaviour
{
    private TextMeshProUGUI __text;
    private void Awake()
    {
        __text = GetComponent<TextMeshProUGUI>();
        __text.text = "������� �� ����������� ����. � ��� " + Subscribers.GetSubscribersAmount + " �����������.  ���������� ������ �������� �����������.";

    }
}
