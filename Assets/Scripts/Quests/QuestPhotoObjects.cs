using System.Collections.Generic;
using UnityEngine;

public class QuestPhotoObjects : MonoBehaviour
{
    [SerializeField] private List<QuestPhotoObject> questPhotoObjects = new();
    [SerializeField] private PhotoCamera photoCamera;

    private static QuestPhotoObjects instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(GlobalVariables.TakePhotoKey))
        {
            QuestPhotoObject capturedQuestObject = photoCamera.IsTargetObjectsCaptured(questPhotoObjects);

            if (capturedQuestObject == null)
                return;

            capturedQuestObject.IncreaceProgress();
            questPhotoObjects.Remove(capturedQuestObject);
        }
    }

    public static void AddQuestPhotoObject(QuestPhotoObject questPhotoObject)
    {
        instance.questPhotoObjects.Add(questPhotoObject);
    }
}