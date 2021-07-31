using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse1 : MonoBehaviour
{
    public Transform target;
    public float xSpeed = 12.0f;
    public float ySpeed = 12.0f;
    public float scrollSpeed = 10.0f;

    public float smoothing = 4f;

    public float zoomMin = 1.0f;

    public float zoomMax = 20.0f;

    float distance;

    public Vector3 position;


    float x = 0.0f;

    float y = 0.0f;


    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

        Vector3 angles = transform.eulerAngles;

        x = angles.y;
        y = angles.x;

    }

 /* void DidLockCursor()
    {
        Debug.Log("Курсор зафиксирован");
    }
    void DidUnlockCursor()
    {
        Debug.Log("Курсор свободен");
    }
    */   
    

    void LateUpdate()
    {
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
            //DidUnlockCursor();

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            //DidLockCursor();
        }

        x += Input.GetAxis("Mouse X") * xSpeed;
        y -= Input.GetAxis("Mouse Y") * ySpeed;

        transform.RotateAround(target.position, transform.up, x);    
        transform.RotateAround(target.position, transform.right, y);

        x = 0;
        y = 0;

        distance = Vector3.Distance(transform.position, target.position);

        distance = ZoomLimit(distance, zoomMin, zoomMax);

        position = -(transform.forward * distance) + target.position;

        if (Input.GetAxis("Mouse ScrollWheel") != 0)

        {

            distance = Vector3.Distance(transform.position, target.position);
            distance = ZoomLimit(distance - Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, zoomMin, zoomMax);
            position = -(transform.forward * distance) + target.position;

            transform.position = Vector3.Lerp(transform.position, position, smoothing * Time.deltaTime);
        }

    }

    public static float ZoomLimit(float dist, float min, float max)

    {

        if (dist < min)

            dist = min;

        if (dist > max)

            dist = max;

        return dist;
    }
}
