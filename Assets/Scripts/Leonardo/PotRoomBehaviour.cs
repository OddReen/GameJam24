using UnityEngine;
using UnityEngine.SceneManagement;

public class PotRoomBehaviour : MonoBehaviour
{
    public static PotRoomBehaviour Instance;

    [SerializeField] Transform[] pots;

    [SerializeField] float distanceToComplete;

    bool isComplete;

    public FMODUnity.EventReference puzzleGood;
    public FMODUnity.EventReference puzzleBad;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (isComplete && Input.GetKey(KeyCode.Space) && RoomHandler.Instance.currentRoom == RoomHandler.RoomType.PurpleRoom)
        {

            PuzzlesController.instance.potPuzzle = true;
            PuzzlesController.instance.CheckAllPuzzles();

            FMODUnity.RuntimeManager.PlayOneShot(puzzleGood);
        }
        else if (!isComplete && Input.GetKey(KeyCode.Space) && RoomHandler.Instance.currentRoom == RoomHandler.RoomType.PurpleRoom)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            FMODUnity.RuntimeManager.PlayOneShot(puzzleBad);
        }
    }

    public void PotsDistance()
    {
        for (int i = 0; i < pots.Length; i++) // First Pot
        {
            float minDis = float.PositiveInfinity;
            Transform minDisTrans = null;

            for (int d = 0; d < pots.Length; d++) // Second Pot
            {
                if (i == d)
                {
                    continue;
                }
                float currentDis = Vector3.Distance(pots[i].position, pots[d].position);
                if (currentDis < minDis)
                {
                    minDis = currentDis;
                    minDisTrans = pots[d];
                }
            }
            if (Vector3.Distance(pots[i].position, minDisTrans.position) < distanceToComplete)
            {
                return;
            }
        }
        Completed();
    }
    private void Completed()
    {
        isComplete = true;
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < pots.Length; i++) // First Pot
        {
            float minDis = float.PositiveInfinity;
            Transform minDisTrans = null;

            for (int d = 0; d < pots.Length; d++) // Second Pot
            {
                if (i == d)
                {
                    continue;
                }
                float currentDis = Vector3.Distance(pots[i].position, pots[d].position);
                if (currentDis < minDis)
                {
                    minDis = currentDis;
                    minDisTrans = pots[d];
                }
            }
            if (Vector3.Distance(pots[i].position, minDisTrans.position) < distanceToComplete)
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.green;
            Gizmos.DrawLine(pots[i].position + Vector3.up * 0.5f, minDisTrans.position + Vector3.up * 0.5f);
        }
    }
}
