using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    [SerializeField] TextMeshPro tutorial1;
    [SerializeField] TextMeshPro tutorial2;
    [SerializeField] TextMeshPro tutorial3;


    bool secondShown = false;
    private void Start()
    {
        instance = this;
    }

    public void ManageTutorial()
    {
        if (!secondShown)
        {
            secondShown = true;
            ShowTutorial();
        }
        else
        {
            RemoveTutorials();
        }
    }

    public void ShowTutorial()
    {
        tutorial2.gameObject.SetActive(true);
        tutorial3.gameObject.SetActive(true);
    }


    public void RemoveTutorials()
    {
        tutorial1.gameObject.SetActive(false);
        tutorial2.gameObject.SetActive(false);
        tutorial3.gameObject.SetActive(false);
    }
}
