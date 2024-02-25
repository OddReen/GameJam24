using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CosmosRoomBehaviour : MonoBehaviour
{
    public static CosmosRoomBehaviour Instance;
    [SerializeField] CosmosPillar[] pillars;

    bool isComplete = false;

    public FMODUnity.EventReference goodSound;
    public FMODUnity.EventReference badSound;
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

    private void Update()
    {
        if (isComplete && Input.GetKeyDown(KeyCode.Space) && RoomHandler.Instance.currentRoom == RoomHandler.RoomType.OrangeRoom)
        {
            FMODUnity.RuntimeManager.PlayOneShot(goodSound);
            Complete();
        }
        else if (!isComplete && Input.GetKeyDown(KeyCode.Space) && RoomHandler.Instance.currentRoom == RoomHandler.RoomType.OrangeRoom)
        {
            FMODUnity.RuntimeManager.PlayOneShot(badSound);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
        isComplete = true;
    }
    private void Complete()
    {
        PuzzlesController.instance.elementsPuzzle = true;
        PuzzlesController.instance.CheckAllPuzzles();
    }
}
