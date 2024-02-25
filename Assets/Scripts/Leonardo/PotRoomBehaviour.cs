using UnityEngine;

public class PotRoomBehaviour : MonoBehaviour
{
    public static PotRoomBehaviour Instance;

    [SerializeField] Transform[] pots;

    [SerializeField] float distanceToComplete;
    private void Awake()
    {
        Instance = this;
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
        Debug.Log("Completed");
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
