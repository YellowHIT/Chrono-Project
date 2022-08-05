using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 //How to use : 
 //Create a empty GameObject and add a BoxCollider to it and set is triggerActive to true
 //add this class to a GameObject with this script
 public class interactTrigger : MonoBehaviour
{
    [SerializeField] public bool triggerActive = false;
    public bool actionTrigger;


    public void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag("MainCamera"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider otherObject)
    {
        if (otherObject.CompareTag("MainCamera"))
        {
            triggerActive = false;
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            triggerAction();
        }
        if(actionTrigger)
        {
            Action();
        }
    }

    //TODO some  action in the world 
    public virtual void triggerAction()
    {
        actionTrigger=true;
        // Debug.Log("Some cool stuff @" + Time.time);
    }

    public virtual void Action()
    {
        Debug.Log("Some action stuff @" + Time.time);
    }
    public virtual void EndAction()
    {
        Debug.Log("action ended @" + Time.time);
    }
    public virtual  
    
    
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        actionTrigger=false;
    
    }


}