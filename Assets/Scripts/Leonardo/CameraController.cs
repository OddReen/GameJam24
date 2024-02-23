using UnityEngine;
public class CameraController : MonoBehaviour
{
    PlayerController playerController;
    InputHandler inputHandler;

    [SerializeField] GameObject cameraTarget;

    public float rotationSpeed = 50f;

    public float topClamp = 85f;
    public float bottomClamp = -85f;

    const float threshold = 0.01f;

    public float cameraTargetPitch;
    public float cameraTargetYaw;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inputHandler = GetComponent<InputHandler>();
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        if (inputHandler.cameraInput.sqrMagnitude >= threshold)
        {
            cameraTargetPitch += -inputHandler.cameraInput.y * rotationSpeed * Time.deltaTime;
            cameraTargetYaw += inputHandler.cameraInput.x * rotationSpeed * Time.deltaTime;
        }

        cameraTargetPitch = ClampAngle(cameraTargetPitch, bottomClamp, topClamp); //Clamp Pitch

        cameraTarget.transform.rotation = Quaternion.Euler(cameraTargetPitch, cameraTargetYaw, 0.0f);
    }
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}
