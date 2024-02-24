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

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
    }
    private void Update()
    {
        StartCoroutine(IsPickingUp());
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
                hit.collider.transform.position = pickUpTransform.position;
                hit.collider.transform.rotation = pickUpTransform.rotation;
                hit.collider.transform.SetParent(pickUpTransform);
                hit.collider.enabled = false;
                pickedUpObject = hit.collider.gameObject;
                hasPickedUp = true;
                StartCoroutine(GhostingHighlight());
            }
        }
    }
    private void Drop()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceToPickUp, ~playerLayer))
        {
            hit.point = pickUpTransform.position;
            pickedUpObject = hit.collider.gameObject;
            hasPickedUp = false;
            StopCoroutine(GhostingHighlight());
        }
    }
    private IEnumerator IsPickingUp()
    {
        yield return new WaitForEndOfFrame();
        inputHandler.isPickingUp = false;
    }
    private IEnumerator GhostingHighlight()
    {
        GameObject gameObject = Instantiate(pickedUpObject);
        gameObject.GetComponent<MeshRenderer>().material = invisible;
        while (true)
        {
            yield return new WaitForEndOfFrame();
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceToPickUp, ~playerLayer))
            {
                gameObject.SetActive(true);
                gameObject.transform.position = hit.point + Vector3.up * .5f;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}