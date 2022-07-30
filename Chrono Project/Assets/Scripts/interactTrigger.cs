using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //How to use : 
 //Create a empty GameObject and add a BoxCollider to it and set is triggerActive to true
 //add this class to a GameObject with this script
 public class interactTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;

    public void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider otherObject)
    {
        if (otherObject.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.e))
        {
            triggerAction();
        }
    }
    //TODO some  action in the world 
    public void triggerAction()
    {
        Debug.Log('Some cool stuff @' + Time.time);
    }
}