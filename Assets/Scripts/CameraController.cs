using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float sensitivity = 2.0f;
    public float minYAngle = -30.0f;
    public float maxYAngle = 60.0f;
    public float distance = 5.0f;
    private float currentX = 0.0f;
    public float heightOffset = 1.0f;
    public Movements movscr;


  public static CameraController instance;


  void Awake()
  {
    instance = this;
  }
    private float currentY = 0.0f;

    // void Update()
    // {
    //   currentX += Input.GetAxis("Mouse X") * sensitivity;
    //   currentY -= Input.GetAxis("Mouse Y") * sensitivity;
    //   currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    // }
   void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get the first touch

            // Check if touch is on the right side of the screen
            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Moved) // if the touch has moved
                {
                    currentX += touch.deltaPosition.x * sensitivity;
                    currentY -= touch.deltaPosition.y * sensitivity;
                    currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
                }
            }
        }
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * dir + Vector3.up * heightOffset;
        transform.rotation = rotation;


        // if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        // {
        //    target.transform.rotation = Quaternion.AngleAxis(currentX, Vector3.up);
        // }

        if (Mathf.Abs(movscr.fixedJoystick.Vertical) > 0f || Mathf.Abs(movscr.fixedJoystick.Horizontal) > 0f)
        {
            target.transform.rotation = Quaternion.AngleAxis(currentX, Vector3.up);

        }
    }
}
