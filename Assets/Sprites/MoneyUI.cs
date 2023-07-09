using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private void Update()
    {
        text.text = "Оставшееся количество монет\n" + Money.GetInstance.GetCurrentMoney.ToString();
    }
}