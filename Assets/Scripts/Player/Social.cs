using System.Collections.Generic;
using UnityEngine;

public class Social : MonoBehaviour
{
    [SerializeField] private Post postPrefab;
    [SerializeField] private RectTransform postsContainer;

    private List<Post> posts = new();

    private void OnEnable()
    {
        GeneratePosts();
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < PhotoCamera.Photos.Count; i++)
        {
            posts[i].UpdateDescription(PhotoCamera.QuestPhotoObjects[i].Description);
            posts[i].UpdateImage(PhotoCamera.Photos[i]);
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