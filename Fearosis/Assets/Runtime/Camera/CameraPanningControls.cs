using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPanningControls : MonoBehaviour
{
    public InputActionAsset inputActions;

    private InputAction panAction;
    //These find the actions for panning in the input actions (because Input... is a crime)

    private Bounds mapBounds;

    private Vector2 minimumCameraPan
    {
        get
        {
            float cameraHalfHeight = Camera.main.orthographicSize;
            float cameraHalfWidth = Camera.main.aspect * cameraHalfHeight;

            return new Vector2(
                mapBounds.min.x + cameraHalfWidth,
                mapBounds.min.y + cameraHalfHeight
            );
        }
    }
    private Vector2 maximumCameraPan
    {
        get
        {
            float cameraHalfHeight = Camera.main.orthographicSize;
            float cameraHalfWidth = Camera.main.aspect * cameraHalfHeight;

            return new Vector2(
                mapBounds.max.x - cameraHalfWidth,
                mapBounds.max.y - cameraHalfHeight
            );
        }
    }

    //Activates the camera for panning, finding the pan actions
    void Awake()
    {
        panAction = inputActions.FindAction("CameraMap/Pan"); //CameraMap is the map, Pan is the action (THE NAMES ARE IMPORTANNT!!!)
        mapBounds = GameObject.FindGameObjectWithTag("Map").GetComponent<SpriteRenderer>().bounds;

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
        Vector3 currentPosition = Camera.main.transform.position;
        Vector2 delta = context.ReadValue<Vector2>();

        // Only apply delta if mouse or touch is pressed
        if ((Mouse.current != null && Mouse.current.leftButton.isPressed) ||
            (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed))
        {
            // Apply delta
            currentPosition -= new Vector3(delta.x, delta.y, 0) * 0.01f;

            // Clamp the new position
            currentPosition.x = Mathf.Clamp(currentPosition.x, minimumCameraPan.x, maximumCameraPan.x);
            currentPosition.y = Mathf.Clamp(currentPosition.y, minimumCameraPan.y, maximumCameraPan.y);

            Camera.main.transform.position = currentPosition;
        }
    }
}
