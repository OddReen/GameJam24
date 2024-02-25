using UnityEngine;

public class CosmosPillar : MonoBehaviour
{
    public bool rightObject = false;
    [SerializeField] public CosmosRoomBehaviour.Type pillarType;

    public void PutObjectOnTop(GameObject gameObject)
    {
        gameObject.transform.SetParent(transform);
        gameObject.transform.position = transform.position + Vector3.up * 1.5f;
        if (gameObject.GetComponent<CosmosObject>().objectType == pillarType)
        {
            rightObject = true;
            VerifyPillars();
        }
        else
            rightObject = false;
    }
    public void VerifyPillars()
    {
        CosmosRoomBehaviour.Instance.VerifyPillars();
    }
}
