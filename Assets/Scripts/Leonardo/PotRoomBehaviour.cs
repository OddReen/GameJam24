using UnityEngine;

public class PotRoomBehaviour : MonoBehaviour
{
    [SerializeField] Transform[] pots;
    bool isCompleted;

    [SerializeField] float distanceToComplete;

    public void ExecutePuzzle()
    {
        //StartCoroutine(DistanceBetweenPots());
    }
    //IEnumerator DistanceBetweenPots()
    //{
    //    while (true)
    //    {
    //        yield return null;
    //        for (int i = 0; i < pots.Length; i++) //First Pot
    //        {

    //            for (int d = 0; d < pots.Length; d++)
    //            {
    //                if (i == d)
    //                {
    //                    continue;
    //                }
    //                if (Vector3.Distance(pots[i].position, pots[d].position))
    //                {

    //                }
    //            }
    //        }
    //    }
    //}
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
            Gizmos.DrawLine(pots[i].position, minDisTrans.position);
        }
    }
}
