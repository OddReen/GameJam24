using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    public static RoomHandler Instance;

    public RoomType LastRoom;
    public RoomType currentRoom;
    InputHandler input;
    public enum RoomType
    {
        WhiteRoom,
        BlueRoom,
        GreenRoom,
        PurpleRoom,
        OrangeRoom
    }

    private void Awake()
    {
        Instance = this;
        currentRoom = RoomType.WhiteRoom;
    }

    private void Update()
    {
        if (input.isChoosing)
        {
            ActivateMinigame(currentRoom);
        }
    }

    public void ActivateMinigame(RoomType roomType)
    {
        currentRoom = roomType;
        switch (currentRoom)
        {
            case RoomType.WhiteRoom:

                break;
            case RoomType.BlueRoom: //arcade room
                PuzzleArcadeMaster.instance.ExecutePuzzle();
                break;
            case RoomType.GreenRoom: // radio room
                RadioRoomBehaviour.Instance.ExecutePuzzle();
                break;
            case RoomType.PurpleRoom: // pots room

                break;
            case RoomType.OrangeRoom: // Elementos room

                break;
        }
    }

}
