using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsManager : MonoBehaviour
{
    public static PortalsManager instance;
    public RoomHandler room;
    Music musica;


    [SerializeField] Portal whitePortalUp;
    [SerializeField] PortalsMaffarico WhiteUPM;

    [SerializeField] Portal whitePortalDown;
    [SerializeField] PortalsMaffarico WhiteDPM;

    [SerializeField] Portal BluePortalUp;
    [SerializeField] PortalsMaffarico BlueUPM;

    [SerializeField] Portal BluePortalDown;
    [SerializeField] PortalsMaffarico BlueDPM;

    [SerializeField] Portal GreenPortalUp;
    [SerializeField] PortalsMaffarico GreenUM;

    [SerializeField] Portal GreenPortalDown;
    [SerializeField] PortalsMaffarico GreenDM;

    [SerializeField] Portal OrangePortalUp;
    [SerializeField] PortalsMaffarico OrangeUM;

    [SerializeField] Portal OrangePortalDown;
    [SerializeField] PortalsMaffarico OrangeDM;

    [SerializeField] Portal PurplePortalUp;
    [SerializeField] PortalsMaffarico PurpleUM;

    [SerializeField] Portal PurplePortalDown;
    [SerializeField] PortalsMaffarico PurpleDM;

    private void Awake()
    {
        instance = this;
    }

    public void SwitchPortals()
    {
        //WhiteOld

        switch (room.LastRoom)
        {
            case RoomHandler.RoomType.WhiteRoom:
                if (room.currentRoom == RoomHandler.RoomType.BlueRoom)
                {
                    UpdatePortalsFunc(BluePortalUp, GreenPortalUp, BluePortalDown, PurplePortalDown, RoomHandler.RoomType.GreenRoom, RoomHandler.RoomType.PurpleRoom);
                    GreenUM.toTP = true;
                    PurpleDM.toTP = true;
                }
                else if (room.currentRoom == RoomHandler.RoomType.GreenRoom)
                {
                    UpdatePortalsFunc(GreenPortalUp, OrangePortalUp, GreenPortalDown, BluePortalDown, RoomHandler.RoomType.OrangeRoom, RoomHandler.RoomType.BlueRoom);
                    OrangeUM.toTP = true;
                    BlueDPM.toTP = true;
                }
                whitePortalUp.linkedPortal = null;
                whitePortalDown.linkedPortal = null;

                break;
            case RoomHandler.RoomType.BlueRoom:
                if (room.currentRoom == RoomHandler.RoomType.GreenRoom)
                {
                    UpdatePortalsFunc(GreenPortalUp, PurplePortalUp, GreenPortalDown, whitePortalDown, RoomHandler.RoomType.PurpleRoom, RoomHandler.RoomType.WhiteRoom);
					musica.ChangeBools(musica.arcadeBool, musica.radioBool);
				}
                else if (room.currentRoom == RoomHandler.RoomType.OrangeRoom)
                {
                    UpdatePortalsFunc(OrangePortalUp, GreenPortalUp, OrangePortalDown, whitePortalDown, RoomHandler.RoomType.GreenRoom, RoomHandler.RoomType.WhiteRoom);
					musica.ChangeBools(musica.arcadeBool, musica.elementBool);
                }
                else if (room.currentRoom == RoomHandler.RoomType.PurpleRoom)
                {
                    UpdatePortalsFunc(PurplePortalUp, whitePortalUp, PurplePortalDown, GreenPortalDown, RoomHandler.RoomType.WhiteRoom, RoomHandler.RoomType.GreenRoom);
					musica.ChangeBools(musica.arcadeBool, musica.greekBool);
                }
                else if (room.currentRoom == RoomHandler.RoomType.WhiteRoom)
                {
                    UpdatePortalsFunc(whitePortalUp, BluePortalUp, whitePortalDown, GreenPortalDown, RoomHandler.RoomType.BlueRoom, RoomHandler.RoomType.GreenRoom);
					musica.ChangeBools(musica.arcadeBool, musica.whiteBool);
                }
                BluePortalUp.linkedPortal = null;
                BluePortalDown.linkedPortal = null;

                break;

            case RoomHandler.RoomType.GreenRoom:
                if (room.currentRoom == RoomHandler.RoomType.BlueRoom)
                {
                    UpdatePortalsFunc(BluePortalUp, whitePortalUp, BluePortalDown, OrangePortalDown, RoomHandler.RoomType.WhiteRoom, RoomHandler.RoomType.OrangeRoom);
					musica.ChangeBools(musica.radioBool, musica.arcadeBool);
                }
                else if (room.currentRoom == RoomHandler.RoomType.PurpleRoom)
                {
                    UpdatePortalsFunc(PurplePortalUp, whitePortalUp, PurplePortalDown, OrangePortalDown, RoomHandler.RoomType.WhiteRoom, RoomHandler.RoomType.OrangeRoom);
                    musica.ChangeBools(musica.radioBool, musica.greekBool);
                }
                else if (room.currentRoom == RoomHandler.RoomType.OrangeRoom)
                {
                    UpdatePortalsFunc(OrangePortalUp, BluePortalUp, OrangePortalDown, whitePortalDown, RoomHandler.RoomType.BlueRoom, RoomHandler.RoomType.WhiteRoom);
                    musica.ChangeBools(musica.radioBool, musica.elementBool);
                }
                GreenPortalUp.linkedPortal = null;
                GreenPortalDown.linkedPortal = null;
                break;

            case RoomHandler.RoomType.PurpleRoom:
                if (room.currentRoom == RoomHandler.RoomType.WhiteRoom)
                {
                    UpdatePortalsFunc(whitePortalUp, BluePortalUp, whitePortalDown, GreenPortalDown, RoomHandler.RoomType.BlueRoom, RoomHandler.RoomType.GreenRoom);
					musica.ChangeBools(musica.greekBool, musica.whiteBool);
                }
                else if (room.currentRoom == RoomHandler.RoomType.BlueRoom)
                {
                    UpdatePortalsFunc(BluePortalUp, whitePortalUp, BluePortalDown, OrangePortalDown, RoomHandler.RoomType.WhiteRoom, RoomHandler.RoomType.OrangeRoom);
                    musica.ChangeBools(musica.greekBool, musica.arcadeBool);
                }
                else if (room.currentRoom == RoomHandler.RoomType.OrangeRoom)
                {
                    UpdatePortalsFunc(OrangePortalUp, GreenPortalUp, OrangePortalDown, whitePortalDown, RoomHandler.RoomType.GreenRoom, RoomHandler.RoomType.WhiteRoom);
					musica.ChangeBools(musica.greekBool, musica.elementBool);
                }
                else if (room.currentRoom == RoomHandler.RoomType.GreenRoom)
                {
                    UpdatePortalsFunc(GreenPortalUp, PurplePortalUp, GreenPortalDown, whitePortalDown, RoomHandler.RoomType.PurpleRoom, RoomHandler.RoomType.WhiteRoom);
					musica.ChangeBools(musica.greekBool, musica.radioBool);
                }
                PurplePortalUp.linkedPortal = null;
                PurplePortalDown.linkedPortal = null;
                break;

            case RoomHandler.RoomType.OrangeRoom:
                if (room.currentRoom == RoomHandler.RoomType.BlueRoom)
                {
                    UpdatePortalsFunc(BluePortalUp, whitePortalUp, BluePortalDown, OrangePortalDown, RoomHandler.RoomType.WhiteRoom, RoomHandler.RoomType.OrangeRoom);
                    musica.ChangeBools(musica.elementBool, musica.arcadeBool);
                }
                else if (room.currentRoom == RoomHandler.RoomType.WhiteRoom)
                {
                    UpdatePortalsFunc(whitePortalUp, BluePortalUp, whitePortalDown, GreenPortalDown, RoomHandler.RoomType.BlueRoom, RoomHandler.RoomType.GreenRoom);
                    musica.ChangeBools(musica.elementBool, musica.whiteBool);
                }
                else if (room.currentRoom == RoomHandler.RoomType.GreenRoom)
                {
                    UpdatePortalsFunc(whitePortalUp, whitePortalUp, whitePortalDown, PurplePortalDown, RoomHandler.RoomType.WhiteRoom, RoomHandler.RoomType.PurpleRoom);
                    musica.ChangeBools(musica.elementBool, musica.radioBool);
                }

                OrangePortalUp.linkedPortal = null;
                OrangePortalDown.linkedPortal = null;
                break;
        }

    }


    public void UpdatePortalsFunc(Portal portal1, Portal portal2, Portal portal3, Portal portal4, RoomHandler.RoomType type1, RoomHandler.RoomType type2)
    {
        portal1.linkedPortal = null;
        portal2.linkedPortal = null;
        portal3.linkedPortal = null;
        portal4.linkedPortal = null;


        portal1.linkedPortal = portal2;
        portal2.linkedPortal = portal1;
        portal1.NextRoomType = type1;


        portal3.linkedPortal = portal4;
        portal4.linkedPortal = portal3;
        portal3.NextRoomType = type2;

        portal1.UpdateTexture();
        portal2.UpdateTexture();
        portal3.UpdateTexture();
        portal4.UpdateTexture();
    }
}
