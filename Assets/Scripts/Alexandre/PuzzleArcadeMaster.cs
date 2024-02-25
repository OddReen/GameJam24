using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleArcadeMaster : MonoBehaviour
{
    public static PuzzleArcadeMaster instance;

    float timeToLock;
    [SerializeField] float minTimeToLock;
    [SerializeField] float maxTimeToLock;

    [SerializeField] PuzzleArcadeScroll[] arcadesScrolls;
    [SerializeField] string[] arcadesCurrentGames;
    [SerializeField] float timeScroll;
    [SerializeField] List<int> shuffledList;
    [SerializeField] Sprite SpaceInvaders;
    [SerializeField] Sprite FinalImage;



    void Start()
    {
        timeToLock = Random.Range(minTimeToLock, maxTimeToLock);
        StartCoroutine(lockGame());
        arcadesCurrentGames = new string[arcadesScrolls.Length];

        instance = this;

    }

    private void Update()
    {
        for (int i = 0; i < arcadesScrolls.Length; i++)
        {
            arcadesCurrentGames[i] = arcadesScrolls[i].currentImage;
        }

        //tirar
        if (Input.GetKeyDown(KeyCode.Space) && RoomHandler.Instance.currentRoom == RoomHandler.RoomType.BlueRoom)
        {
            ExecutePuzzle();
        }
    }

    IEnumerator lockGame()
    {
        yield return new WaitForSeconds(timeToLock);

        arcadesScrolls[0].CancelInvoke();
        arcadesScrolls[0].rend.sprite = SpaceInvaders;
        arcadesScrolls[0].currentImage = "SpaceInvaders";

        yield return new WaitForSeconds(2);

        arcadesScrolls[0].StartScroll();

        timeToLock = Random.Range(minTimeToLock, maxTimeToLock);
        StartCoroutine(lockGame());
    }

    public void ExecutePuzzle()
    {
        //int counterGames = 0;

        //for (int i = 0; i < arcadesCurrentGames.Length; i++)
        //    if (arcadesCurrentGames[i] == "SpaceInvaders")
        //{
        //    {
        //        counterGames++;
        //    }
        //}

        //if (counterGames >= 3)
        //{
        //    Debug.Log("Win");
        //}
        //else
        //{
        //    Debug.Log("Lose");
        //}

        if (arcadesScrolls[0].currentImage == "SpaceInvaders")
        {

            Debug.Log("Win");
            StopAllCoroutines();
            for (int i = 0; i < arcadesScrolls.Length; i++)
            {
                arcadesScrolls[i].CancelInvoke();
                arcadesScrolls[i].rend.sprite = FinalImage;
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
