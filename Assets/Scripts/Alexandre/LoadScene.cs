using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int indexToLoad;

    public void ChangeScene()
    {
        SceneManager.LoadScene(indexToLoad);
    }
}
