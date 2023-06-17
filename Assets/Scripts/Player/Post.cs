using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Post : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image photo;

    public void UpdateDescription(string text)
    {
        description.text = text;
    }

    public void UpdateImage(Sprite sprite)
    {
        photo.sprite = sprite;
    }
}