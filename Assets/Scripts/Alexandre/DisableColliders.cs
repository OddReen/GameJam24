using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliders : MonoBehaviour
{
    public Collider collToDisable;

    private void OnTriggerStay(Collider other)
    {
        collToDisable.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        collToDisable.enabled = false;
    }

}
