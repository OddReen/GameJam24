using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RadioRoomBehaviour : MonoBehaviour
{
    public static RadioRoomBehaviour Instance;

    [SerializeField] Transform radio;
    [SerializeField] EventReference radioVoiceEvent;
    EventInstance radioVoice;

    [SerializeField] float beginSpace;
    [SerializeField] float endSpace;
    [SerializeField] float endSound;
    [SerializeField] bool canPress = false;

    [SerializeField] float timerSpace;

    private void Start()
    {
        Instance = this;
        radioVoice = RuntimeManager.CreateInstance(radioVoiceEvent);
        ExecutePuzzle();
    }

    private void Update()
    {
        if (canPress && Input.GetKey(KeyCode.Space) && RoomHandler.Instance.currentRoom == RoomHandler.RoomType.GreenRoom)
        {
            FMODUnity.EventReference puzzleGood;
            FMODUnity.EventReference puzzleBad;

            radioVoice.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            PuzzlesController.instance.radioPuzzle = true;
            PuzzlesController.instance.CheckAllPuzzles();
        }
        else if (!canPress && Input.GetKey(KeyCode.Space) && RoomHandler.Instance.currentRoom == RoomHandler.RoomType.GreenRoom)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ExecutePuzzle()
    {
        StartCoroutine(TimingToChoose());
    }
    IEnumerator TimingToChoose()
    {
        radioVoice.start();
        RuntimeManager.AttachInstanceToGameObject(radioVoice, radio);
        yield return new WaitForSeconds(beginSpace);
        canPress = true;
        yield return new WaitForSeconds(endSpace);
        canPress = false;
        yield return new WaitForSeconds(endSound);

        yield return new WaitForSeconds(5f);
        ExecutePuzzle();
    }


}
