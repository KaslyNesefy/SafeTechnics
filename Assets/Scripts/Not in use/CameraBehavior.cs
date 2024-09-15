using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/CameraBehavior")]
public class CameraBehavior : MonoBehaviour
{
    public enum RotationAxies { MouseXandY = 0, MouseX = 1, MouseY = 2}
    public RotationAxies axes = RotationAxies.MouseXandY;
    public float sensivityX = 0.5f;
    public float sensivityY = 0.5f;
    public float minimumX = -360f;
    public float maximumX = 360f;
    public float minimumY = -360f;
    public float maximumY = 360f;

    float rotationX = 0f;
    float rotationY = 0f;

    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        //if (GetComponent<Rigidbody>())
        //{
        //    GetComponent<Rigidbody>().freezeRotation = true;
        //}
        originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle < +360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxies.MouseXandY)
        {
            rotationX += Input.GetAxis("Mouse X") * sensivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensivityY;
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.right);
            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        else if (axes == RotationAxies.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation* xQuaternion;
        }
        else if (axes == RotationAxies.MouseY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }
}
