using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform PositionToTeleport;
    public void TeleportGameObject()
    {
        transform.position = PositionToTeleport.position;
    }
}
