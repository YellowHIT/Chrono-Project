using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorEntrance : interactTrigger
{
    private bool opened;
    private bool canClose;

    private Vector3 positionLeft;
    private Vector3 positionRight;
    
    private Transform childLeft;
    private Transform childRight;

    public override void Action()
    {
        // Debug.Log("opening door @" + Time.time);
        // transform.GetChild(0).transform.Translate(Vector3.up *Time.deltaTime);
        // int count = transform.childCount;


        if(opened==false)
        {
            // Debug.Log("Opening");
            childLeft.Translate(Vector3.left*2.0f*Time.deltaTime);
            
            childRight.Translate(Vector3.right*2.0f*Time.deltaTime);
        }
        else if(canClose == true)
        {
            // if (other.gameObject.CompareTag("Player"))
            // {
            //     enemyStopped = true;
            //     StartCoroutine(MovementCooldown());
            //     if(enemyStopped = true)
            //     {
            //         enemyMeleeSpeed = 0;
            //     }
            // }
            childLeft.Translate(Vector3.right*2.00f*Time.deltaTime);            
            childRight.Translate(Vector3.left*2.00f*Time.deltaTime);
        }
    }
    // private void OnTriggerEnter(Collider other)
    // {


    // }
    public override void triggerAction()
    {
        childRight = transform.GetChild(1);
        childLeft  = transform.GetChild(2);
        positionLeft = childLeft.transform.position;
        positionRight = childRight.transform.position;
        opened=false;
        actionTrigger=true;
        StartCoroutine(ExecuteAfterTime(0.5f));
        // Debug.Log("Some cool stuff @" + Time.time);
    }
    
    public override IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        // actionTrigger=false;
        opened=true;
        StartCoroutine(wait(2.0f));

    }

    public IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        canClose = true;
        StartCoroutine(ResolveAfterTime(0.5f));
    }

    public IEnumerator ResolveAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        opened=false;
        actionTrigger=false;
        canClose = false;
        childLeft.transform.position  = positionLeft;
        childRight.transform.position = positionRight;

    }

}
