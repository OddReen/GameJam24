using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmosRoomBehaviour : MonoBehaviour
{
    public static CosmosRoomBehaviour Instance;
    [SerializeField] CosmosPillar[] pillars;

    public enum Type
    {
        White,
        Blue,
        Green,
        Red
    }

    private void Awake()
    {
        Instance = this;
    }
    public void VerifyPillars()
    {
        for (int i = 0; i < pillars.Length; i++)
        {
            if (!pillars[i].GetComponent<CosmosPillar>().rightObject)
            {
                return;
            }
        }
        Complete();
    }
    private void Complete()
    {
        Debug.Log("Complete");
    }
}
