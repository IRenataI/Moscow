using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    
    private static SaveProgress __instance;
    private void Awake()
    {
        if (!__instance) { __instance = this; DontDestroyOnLoad(gameObject);  } else { Destroy(gameObject); }
    }
}
