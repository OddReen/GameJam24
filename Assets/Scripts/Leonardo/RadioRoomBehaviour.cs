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

    public FMODUnity.EventReference puzzleGood;
    public FMODUnity.EventReference puzzleBad;

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

            FMODUnity.RuntimeManager.PlayOneShot(puzzleGood);
            radioVoice.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            PuzzlesController.instance.radioPuzzle = true;
            PuzzlesController.instance.CheckAllPuzzles();
        }
        else if (!canPress && Input.GetKey(KeyCode.Space) && RoomHandler.Instance.currentRoom == RoomHandler.RoomType.GreenRoom)
        {
            FMODUnity.RuntimeManager.PlayOneShot(puzzleBad);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            radioVoice.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
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
