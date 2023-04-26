using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private float rotationX;
    private float rotationY;
    public float sensitivity = 100f;

    private float mouseX;
    private float mouseY;

    private float joystickX;
    private float joystickY;

    //public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard and mouse controll
        
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        MovementPlayerAndCam(mouseX, mouseY);
        

        //Joystick controll

        joystickX = Input.GetAxis("RightJoystickX") * sensitivity * Time.deltaTime;
        joystickY = Input.GetAxis("RightJoystickY") * sensitivity * Time.deltaTime;

        MovementPlayerAndCam(joystickX, joystickY); 
    }

    void MovementPlayerAndCam(float x, float y)
    {
        rotationX -= y;
        rotationY += x;

        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);

        //playerBody.Rotate(Vector3.up * x);
    }
}
