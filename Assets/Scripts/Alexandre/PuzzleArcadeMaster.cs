using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleArcadeMaster : MonoBehaviour
{
    float timeToLock;
    [SerializeField] float minTimeToLock;
    [SerializeField] float maxTimeToLock;

    [SerializeField] PuzzleArcadeScroll[] arcadesScrolls;
    [SerializeField] float timeScroll;
    [SerializeField] List<int> shuffledList;


    void Start()
    {
        timeToLock = Random.Range(minTimeToLock, maxTimeToLock);
        StartCoroutine(lockGame());
        //InvokeRepeating(nameof(GenerateRandomImage), timeScroll, timeScroll);

    }

    void GenerateRandomImage(int arrayLength)
    {
        do
        {
            shuffledList = new List<int>();

            for (int i = 0; i < arrayLength; i++)
            {
                shuffledList.Add(i);
            }

            shuffledList = shuffledList.OrderBy(x => Random.value).ToList();

            for (int i = 0; i < arcadesScrolls.Length; i++)
            {
                arcadesScrolls[i].rend.sprite = arcadesScrolls[i].ImagesScroll[shuffledList[i]];
                arcadesScrolls[i].ImagesIndex = shuffledList[i];
            }
        } while
        (arcadesScrolls[0].lastIndex == arcadesScrolls[0].ImagesIndex &&
        arcadesScrolls[1].lastIndex == arcadesScrolls[1].ImagesIndex &&
        arcadesScrolls[2].lastIndex == arcadesScrolls[2].ImagesIndex
        );
    }

    IEnumerator lockGame()
    {
        yield return new WaitForSeconds(timeToLock);

        arcadesScrolls[0].CancelInvoke();
        arcadesScrolls[1].CancelInvoke();
        arcadesScrolls[2].CancelInvoke();

        arcadesScrolls[0].rend.sprite = arcadesScrolls[0].ImagesScroll[0];
        arcadesScrolls[1].rend.sprite = arcadesScrolls[1].ImagesScroll[0];
        arcadesScrolls[2].rend.sprite = arcadesScrolls[2].ImagesScroll[0];

        yield return new WaitForSeconds(3);

        for (int i = 0; i < arcadesScrolls.Length; i++)
        {
            arcadesScrolls[i].StartScroll();
        }

        timeToLock = Random.Range(minTimeToLock, maxTimeToLock);
        StartCoroutine(lockGame());
    }


}
