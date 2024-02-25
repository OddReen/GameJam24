using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] TextMeshPro tutorial1;
    [SerializeField] TextMeshPro tutorial2;
    [SerializeField] TextMeshPro tutorial3;

    

    public void RemoveTutorials()
    {
        tutorial1.gameObject.SetActive(false);
        tutorial2.gameObject.SetActive(false);
        tutorial3.gameObject.SetActive(false);
    }
}
