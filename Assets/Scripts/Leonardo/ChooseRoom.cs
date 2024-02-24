using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRoom : MonoBehaviour
{
    [SerializeField] RoomHandler.RoomType roomToTeleport;

    public void ExecuteTeleport()
    {
        RoomHandler.Instance.ActivateMinigame(roomToTeleport);
    }
}
