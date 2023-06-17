using System.Collections.Generic;
using UnityEngine;

public class Social : MonoBehaviour
{
    [SerializeField] private Post postPrefab;
    [SerializeField] private RectTransform postsContainer;

    public List<Post> posts = new();

    private void OnEnable()
    {
        GeneratePosts();
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = PhotoCamera.Photos.Count - 1; i >= 0; i--)
        {
            posts[PhotoCamera.Photos.Count - 1 - i].UpdateDescription(PhotoCamera.QuestPhotoObjects[i].Description);
            posts[PhotoCamera.Photos.Count - 1 - i].UpdateImage(PhotoCamera.Photos[i]);
        }
    }

    private void GeneratePosts()
    {
        while (PhotoCamera.Photos.Count > posts.Count)
        {
            posts.Add(Instantiate(postPrefab, postsContainer));
        }
    }
}