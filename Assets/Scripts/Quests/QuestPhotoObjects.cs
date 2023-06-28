using UnityEngine;

public class QuestPhotoObjects : MonoBehaviour
{
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
            QuestPhotoObject capturedQuestObject = photoCamera.IsTargetObjectsCaptured();
            if (capturedQuestObject == null)
                return;

            Debug.Log("capturedQuestObject: " + capturedQuestObject);
            if (capturedQuestObject.AllowQuest)
            {
                photoCamera.AddPhoto(capturedQuestObject);

                Quest quest = capturedQuestObject.GetComponent<Quest>();
                
                if (quest.QuestStatus == Quest.QuestStatuses.None)
                    quest.StartQuest(0);
                if (quest.QuestStatus == Quest.QuestStatuses.Started)
                    capturedQuestObject.IncreaceProgress();
            }
        }
    }
}