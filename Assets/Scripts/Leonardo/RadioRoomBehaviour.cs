using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;


public class RadioRoomBehaviour : MonoBehaviour
{
    public static RadioRoomBehaviour Instance;

    [SerializeField] Transform radio;
    [SerializeField] EventReference radioVoiceEvent;
    EventInstance radioVoice;

    [SerializeField] float beginSpace;
    [SerializeField] float endSpace;
    [SerializeField] float endSound;
    bool canPress = false;
    bool isPlaying = true;

    private void Start()
    {
        Instance = this;
        radioVoice = RuntimeManager.CreateInstance(radioVoiceEvent);
    }
    public void ExecutePuzzle()
    {
        StartCoroutine(TimingToChoose());
    }
    IEnumerator TimingToChoose()
    {
        radioVoice.start();
        RuntimeManager.AttachInstanceToGameObject(radioVoice, radio);
        while (isPlaying)
        {
            yield return new WaitForSeconds(beginSpace);
            canPress = true;
            yield return new WaitForSeconds(endSpace);
            canPress = false;
            yield return new WaitForSeconds(endSound);
        }
        canPress = false;
    }

}
