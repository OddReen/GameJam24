using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputHandler _inputHandler;

    public Rigidbody _rigidbody;

    [Header("Stats")]
    [SerializeField] public float currentSpeed;
    [SerializeField] float walkingSpeed = 5;
    [SerializeField] float runningSpeed = 8;
    [SerializeField] float blendSpeed;
    [SerializeField] public float rotationSpeed = 10;

    [Header("Direction")]
    public Vector3 moveDirectionWorldRelative;
    public Vector3 moveDirectionCameraRelative;

    [Header("IsGrounded")]
    [SerializeField] bool isGrounded;
    [SerializeField] float sphereOverlapHeight;
    [SerializeField] float sphereOverlapRadius;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float rayDistanceDown;
    [SerializeField] Vector3 rayHit;

    [Header("Gizmos")]
    [SerializeField] bool playerDirectionGizmo;
    [SerializeField] bool isGroundedGizmo;
    bool triggerOffTheGround = false;

    [Header("Bolleans")]
    [SerializeField] public bool canRotate = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputHandler = GetComponent<InputHandler>();
    }
    private void FixedUpdate()
    {
        IsGrounded();
        Movement();
        Rotation();
    }
    private void Movement()
    {
        if (!isGrounded)
            return;
        moveDirectionWorldRelative = new Vector3(_inputHandler.movementInput.x, 0, _inputHandler.movementInput.y);

        moveDirectionCameraRelative = (new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * moveDirectionWorldRelative.z) + (new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * moveDirectionWorldRelative.x);
        moveDirectionCameraRelative.Normalize();

        float targetSpeed = _inputHandler.isRunning ? runningSpeed : walkingSpeed;

        if (_inputHandler.isRunning && _inputHandler.movementInput.magnitude > 0.1f)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Time.deltaTime * blendSpeed);
        }
        else if (_inputHandler.movementInput.magnitude > 0.1f)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Time.deltaTime * blendSpeed);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, Time.deltaTime * blendSpeed);
        }
        Vector3 moveVelocity = moveDirectionCameraRelative * targetSpeed;

        moveVelocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = moveVelocity;
    }
    private void Rotation()
    {
        if (moveDirectionWorldRelative != Vector3.zero && canRotate)
        {
            float _targetRotation = Mathf.Atan2(moveDirectionWorldRelative.x, moveDirectionWorldRelative.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float rotation = Mathf.LerpAngle(transform.eulerAngles.y, _targetRotation, Time.deltaTime * rotationSpeed);

            _rigidbody.MoveRotation(Quaternion.Euler(0.0f, rotation, 0.0f));
        }
    }
    private bool IsGrounded()
    {
        if (Physics.CheckSphere(transform.position + Vector3.up * sphereOverlapHeight, sphereOverlapRadius, ~layerMask))
        {
            isGrounded = true;
            return isGrounded;
        }
        else
        {
            isGrounded = false;
            return isGrounded;
        }
    }
    private void OnDrawGizmos()
    {
        if (playerDirectionGizmo)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + moveDirectionCameraRelative + Vector3.up);
            Gizmos.DrawWireSphere(transform.position + moveDirectionCameraRelative + Vector3.up, .25f);
        }
        if (isGroundedGizmo)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position + Vector3.up * sphereOverlapHeight, sphereOverlapRadius);
        }
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayDistanceDown);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistanceDown, ~layerMask))
        {
            Gizmos.DrawLine(hit.point, hit.point + hit.normal);
        }
    }
}