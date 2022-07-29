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
        Vector3 tmp =  transform.position;
        tmp.x = Mathf.Round((tmp.x-moveTo.x)*100f) / 100f;
        tmp.z = Mathf.Round((tmp.z-moveTo.z)*100f) / 100f;

        // Debug.Log(tmp);
        if(tmp.x != 0 || tmp.z != 0)
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
