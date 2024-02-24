using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public InputActions inputActions;

    public Vector2 movementInput;
    public Vector2 cameraInput;
    public bool isChoosing;
    public bool isPickingUp;
    public bool isRunning;

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new InputActions();
            inputActions.Gameplay.Movement.performed += context => movementInput = context.ReadValue<Vector2>();
            inputActions.Gameplay.Movement.canceled += context => movementInput = context.ReadValue<Vector2>();

            inputActions.Gameplay.Camera.performed += context => cameraInput = context.ReadValue<Vector2>();
            inputActions.Gameplay.Camera.canceled += context => cameraInput = context.ReadValue<Vector2>();

            inputActions.Gameplay.Choose.performed += context => isChoosing = context.ReadValueAsButton();
            inputActions.Gameplay.Choose.canceled += context => isChoosing = context.ReadValueAsButton();

            inputActions.Gameplay.PickUp.performed += context => isPickingUp = context.ReadValueAsButton();
            inputActions.Gameplay.PickUp.canceled += context => isPickingUp = context.ReadValueAsButton();

            inputActions.Gameplay.Run.performed += context => isRunning = context.ReadValueAsButton();
            inputActions.Gameplay.Run.canceled += context => isRunning = context.ReadValueAsButton();

        }
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}