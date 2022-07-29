using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float mouseRotationSpeed;

    private Animator playerAnim;

    void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = 0;//Zero
        float zInput = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(xInput,yInput,zInput);

        //aply movement to scene
        transform.Translate(movementVector * playerSpeed * Time.deltaTime, Space.Self);


    }
    void lookAtMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        
        Vector3 cameraPosition = transform.position;

        mousePos.y -= cameraPosition.x;
        mousePos.x -= cameraPosition.y;

        transform.eulerAngles = (new Vector3(-mousePos.y,mousePos.x,0) * mouseRotationSpeed);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //calling movement func
        Movement();

        lookAtMouse();
        
    }
}
