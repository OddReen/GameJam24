using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsMaffarico : MonoBehaviour
{
    public Vector3 positionBehind;
    public Vector3 positionFront;
    public bool toTP;



    void Update()
    {
        if (toTP)
        {
            transform.localPosition = positionFront;
        }
        else
        {
            transform.localPosition = positionBehind;
        }

    }

    public void SwitchPlace(bool toFront)
    {
        if (toFront)
        {
            transform.localPosition = positionFront;
        }
        else
        {
            transform.localPosition = positionBehind;
        }
    }
}
