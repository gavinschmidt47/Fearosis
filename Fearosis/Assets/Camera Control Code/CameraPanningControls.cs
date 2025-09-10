using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPanningControls : MonoBehaviour
{
    public InputActionAsset inputActions;

    private InputAction panAction;
    //These find the actions for panning in the input actions (because Input... is a crime)

    //Activates the camera for panning, finding the pan actions
    void Awake()
    {
        panAction = inputActions.FindAction("CameraMap/Pan"); //CameraMap is the map, Pan is the action (THE NAMES ARE IMPORTANNT!!!)
    }

    void OnEnable()
    {
        panAction.performed += OnPanPerformed;
        panAction.Enable();
    }

    void OnDisable()
    {
        panAction.performed -= OnPanPerformed;
        panAction.Disable();
    }

    //OnEnable & OnDisable that activate and deactivate the panning action, this (hopefully) will let you just tap stuff normally when we include that

    private void OnPanPerformed(InputAction.CallbackContext context)
    {
        // Mouse drag (Editor)
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            Vector2 delta = context.ReadValue<Vector2>();
            Camera.main.transform.position -= new Vector3(delta.x, delta.y, 0) * 0.01f;
        }
        // Touch drag (Mobile)
        else if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 delta = context.ReadValue<Vector2>();
            Camera.main.transform.position -= new Vector3(delta.x, delta.y, 0) * 0.01f;
            //Delta is the input, works for both mouse and touch
        }
    }
}
