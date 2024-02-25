using System.Collections;
using UnityEngine;
public class PickUpHandler : MonoBehaviour
{
    InputHandler inputHandler;

    [SerializeField] bool hasPickedUp;
    [SerializeField] Transform pickUpTransform;
    [SerializeField] float distanceToPickUp;
    [SerializeField] LayerMask playerLayer;

    [SerializeField] GameObject pickedUpObject;

    [SerializeField] Material invisible;
    GameObject ghostObject;

    Coroutine coroutine;


    public FMODUnity.EventReference pickUpSound;
    public FMODUnity.EventReference DropSound;
    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
    }
    private void Update()
    {
        StartCoroutine(IsPickingUp());

        if (hasPickedUp)
        {
            pickedUpObject.transform.position = pickUpTransform.position;
        }

        if (inputHandler.isPickingUp && !hasPickedUp)
        {
            PickUp();
        }
        else if (inputHandler.isPickingUp && hasPickedUp)
        {
            Drop();
        }
    }
    private void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceToPickUp, ~playerLayer))
        {
            if (hit.collider.CompareTag("Pickable"))
            {
                pickedUpObject = hit.collider.gameObject;
                pickedUpObject.transform.SetParent(null);
                pickedUpObject.transform.position = pickUpTransform.position;
                pickedUpObject.transform.rotation = Quaternion.Euler(-90, pickUpTransform.rotation.y, pickUpTransform.rotation.z);

                pickedUpObject.GetComponent<Collider>().enabled = false;
                hasPickedUp = true;
                coroutine = StartCoroutine(GhostingHighlight());
                FMODUnity.RuntimeManager.PlayOneShot(pickUpSound);
            }
        }
    }
    private void Drop()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceToPickUp, ~playerLayer))
        {
            if (hit.collider.CompareTag("Pillar"))
            {
                if (hit.collider.transform.childCount == 0)
                {
                    hit.collider.GetComponent<CosmosPillar>().PutObjectOnTop(pickedUpObject);

                    pickedUpObject.GetComponent<Collider>().enabled = true;
                    hasPickedUp = false;
                    StopCoroutine(coroutine);
                    Destroy(ghostObject);
                    pickedUpObject = null;
                    FMODUnity.RuntimeManager.PlayOneShot(DropSound);
                }
                return;
            }
            pickedUpObject.transform.parent = null;
            pickedUpObject.transform.position = hit.point;
            pickedUpObject.GetComponent<Collider>().enabled = true;
            pickedUpObject.transform.rotation = Quaternion.Euler(-90, 0, 0); // MAD CODE HERE!!!!!!!!!
            hasPickedUp = false;
            StopCoroutine(coroutine);
            Destroy(ghostObject);
            pickedUpObject = null;
            PotRoomBehaviour.Instance.PotsDistance();
        }
    }
    private IEnumerator IsPickingUp()
    {
        yield return new WaitForEndOfFrame();
        inputHandler.isPickingUp = false;
    }
    private IEnumerator GhostingHighlight()
    {
        ghostObject = Instantiate(pickedUpObject);
        ghostObject.GetComponent<MeshRenderer>().material = invisible;
        while (true)
        {
            yield return null;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceToPickUp, ~playerLayer))
            {
                ghostObject.SetActive(true);
                ghostObject.transform.position = hit.point;
                ghostObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
            }
            else
            {
                ghostObject.SetActive(false);
            }
        }
    }
}