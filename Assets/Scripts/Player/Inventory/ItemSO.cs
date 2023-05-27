using UnityEngine;

[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    [SerializeField] private string id;
    public string Id => id;
}