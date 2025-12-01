using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch; //Enhanced touch makes it so we don't have to make a whole input action just for zooming

public class CameraZoomControls : MonoBehaviour
{
    // Values for zooming, worked with serialized fields
    [SerializeField] private float zoomSpeed = 0.1f;
    private Camera cam;

    private float maxZoom
    {
        get
        {
            return Mathf.Min(mapBounds.size.x / (2f * cam.aspect), mapBounds.size.y / 2f);
        }
    }

    [SerializeField] private float minZoom = 2f;


    private Bounds mapBounds;

    //Activates touch support
    private void Awake()
    {
        cam = GetComponent<Camera>();
        mapBounds = GameObject.FindGameObjectWithTag("Map").GetComponent<SpriteRenderer>().bounds;
        EnhancedTouchSupport.Enable(); //Enable Enhanced Touch
    }


    void Update()
    {
        //Touch input for phones
        if (UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches.Count >= 2) //This checks that you touch the screen with two fingers
        {
            //Activates your two seperate touches
            var touch0 = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0];
            var touch1 = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[1];

            Vector2 touch0PrevPos = touch0.screenPosition - touch0.delta;
            Vector2 touch1PrevPos = touch1.screenPosition - touch1.delta;

            //Moves the camera based off of the screen's current/past position and your finger's current/past positions
            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.screenPosition - touch1.screenPosition).magnitude;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            ZoomCamera(deltaMagnitudeDiff * zoomSpeed);
        }
        // Mouse scroll wheel for general simulation
        else
        {
            float scroll = Mouse.current != null ? Mouse.current.scroll.ReadValue().y : 0f;
            if (Mathf.Abs(scroll) > 0.01f)
            {
                ZoomCamera(-scroll * zoomSpeed);
            }
        }
    }

    private void ZoomCamera(float zoomAmount)
    {
        //Checks if camera is orthographic or not, in case we mess with the camera/game in some way to make it "3D"
        if (cam.orthographic)
        {
            cam.orthographicSize += zoomAmount;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
        //else
        //{
        //    cam.fieldOfView += zoomAmount;
        //    cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minZoom, maxZoom);
        //}
    }
}
