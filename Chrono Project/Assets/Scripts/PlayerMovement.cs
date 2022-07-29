using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float mouseRotationSpeed;
    public float lookXLimitUp;
    public float lookXLimitDown;
    public float x, y, z;
    
    CharacterController characterController;

    

    public void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = 0;//Zero
        float zInput = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(xInput,yInput,zInput);

        //aply movement to scene
        transform.Translate(movementVector * playerSpeed * Time.deltaTime, Space.Self);
        transform.position = new Vector3(transform.position.x + x/100, 1.661f + y/100, transform.position.z + z/100);

        


    }
    void lookAtMouse()
    {
        Vector3 rotation;
        
        rotation.y =  Input.GetAxis("Mouse X") * mouseRotationSpeed;
        rotation.x = -Input.GetAxis("Mouse Y") * mouseRotationSpeed;
        
        transform.Rotate(rotation.x,rotation.y,0);
        //cancel z rotation that was added by Euler Angles 
        float z = transform.eulerAngles.z;
        transform.Rotate(0, 0, -z);
        //limits the player camera in X axis
        float x = transform.eulerAngles.x;
        if(x > lookXLimitDown && x < lookXLimitUp)
        {
            // Debug.Log(transform.eulerAngles.x);
            if(x < 180)
                transform.Rotate(lookXLimitDown-x, 0, 0);
            else
                transform.Rotate(lookXLimitUp-x, 0, 0);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //calling movement func
        Movement();

        lookAtMouse();
        
    }
}
