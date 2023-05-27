using TMPro;
using UnityEngine;

public class GuitarUICounter : MonoBehaviour
{
    private TextMeshProUGUI __counter;
    private void Awake()
    {
        __counter = GetComponent<TextMeshProUGUI>();
    }
    public void ChangeText(string text)
    {
        __counter.text = text;
    }
}
