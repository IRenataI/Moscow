using UnityEngine;

public class QuestStorage : MonoBehaviour
{
    [SerializeField]private Quest[] CurrentQuests;
    const int MAINQUESTLENGTH = 5;
    private bool[] __mainQuests = new bool[MAINQUESTLENGTH];
    public bool[] GetMainQuests { get { return __mainQuests; } }
    public static int GetMainQuestsLength => MAINQUESTLENGTH;
    private static QuestStorage __instance;
    public static QuestStorage GetInstance => __instance;
    private void Awake()
    {
        if (!__instance) {__instance = this;} else {Destroy(gameObject); }
    }
    public int GetIndexByQuest(Quest quest)
    {
        for (int i = 0; i < CurrentQuests.Length; i++)
        {
            if (CurrentQuests[i] == quest)
            {
                return i;
            }
        }
        return -1;
    }
}