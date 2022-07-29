using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public GameObject camera;
    private float speed;
    Transform vector;

    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        vector = camera.GetComponent<Transform>();
        speed = camera.GetComponent<PlayerMovement>().playerSpeed;
        //Debug.Log(vector);

        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        
        
    }
    void LateUpdate()
    {
        playerAnim.SetBool("Move", false);
        MoveTo();
    }

    void MoveTo()
    {
        Vector3 moveTo = new Vector3(vector.position.x , 0.05f, vector.position.z);
        
        Debug.Log(moveTo + " " + transform.position);
        if(moveTo.x != transform.position.x || moveTo.z != transform.position.z)
        {
            playerAnim.SetBool("Move", true);//TODO
        }
        else
        {
            playerAnim.SetBool("Move", false); //TODO
        }

        transform.position = moveTo;
    }


    void Rotation()
    {
       Vector3 rotationdiff = vector.eulerAngles - transform.eulerAngles;
       transform.Rotate(0, rotationdiff.y, 0);
       //Debug.Log(rotationdiff);
    }
}
