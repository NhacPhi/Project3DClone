using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThirdCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distanceFromTarget = 3.0f;
    [SerializeField]
    private float mouseSensitivity = 1;

    private Vector3 currentRotation;
    private Vector3 currentVelocity = Vector3.zero;

    private float rotationX;
    private float rotationY;

    [SerializeField]
    public float smoothTime = 0.3f;
    [SerializeField]
    private Vector2 rotationXMinMax = new Vector2(-40, 40);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraControl();
    }

    void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationY += mouseX;

        rotationX = Mathf.Clamp(rotationX, rotationXMinMax.x, rotationXMinMax.y);
        Vector3 nextRotation = new Vector3(rotationX, rotationY);

        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref currentVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
