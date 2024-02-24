using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleArcadeScroll : MonoBehaviour
{
    public Sprite[] ImagesScroll;
    public string[] ImagesName;
    public string currentImage;
    public Image rend;

    float timeToLock;
    [SerializeField] float minTimeToLock;
    [SerializeField] float maxTimeToLock;


    public int ImagesIndex;
    public int lastIndex;
    [SerializeField] float timeScroll;


    void Start()
    {
        ImagesIndex = Random.Range(0, ImagesScroll.Length);
        lastIndex = ImagesIndex;
        rend.sprite = ImagesScroll[ImagesIndex];
        currentImage = ImagesName[ImagesIndex];

        StartScroll();
    }

    public void StartScroll()
    {
        InvokeRepeating(nameof(ScrollImages), timeScroll, timeScroll);
    }

    public void ScrollImages()
    {
        do
        {
            ImagesIndex = Random.Range(1, ImagesScroll.Length);
            Debug.Log("Random: " + ImagesIndex + " | last index: " + lastIndex);
        } while (ImagesIndex == lastIndex);

        rend.sprite = ImagesScroll[ImagesIndex];
        currentImage = ImagesName[ImagesIndex];
        lastIndex = ImagesIndex;
    }

    IEnumerator LockImages()
    {
        CancelInvoke();
        yield return new WaitForSeconds(timeToLock);

    }

}
