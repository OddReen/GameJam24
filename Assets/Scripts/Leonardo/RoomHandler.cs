using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    public static RoomHandler Instance;
    [SerializeField] RoomType roomToTeleport;

    public RoomType currentRoom;

    public enum RoomType
    {
        WhiteRoom,
        ArcadeRoom,
        RadioRoom,
        PotRoom,
        CosmosRoom
    }

    private void Awake()
    {
        Instance = this;
        currentRoom = RoomType.WhiteRoom;
    }

    public void ActivateMinigame(RoomType roomType)
    {
        currentRoom = roomType;
        switch (currentRoom)
        {
            case RoomType.WhiteRoom:
                break;
            case RoomType.ArcadeRoom:

                break;
            case RoomType.RadioRoom:
                RadioRoomBehaviour.Instance.ExecutePuzzle();
                break;
            case RoomType.PotRoom:

                break;
            case RoomType.CosmosRoom:

                break;
        }
    }

}
