using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntrance : interactTrigger
{
    public override void Action()
    {
        // Debug.Log("opening door @" + Time.time);
        // transform.GetChild(0).transform.Translate(Vector3.up *Time.deltaTime);
        int count = transform.childCount;
        for(int i = 1; i < count; i++)
        {
            Transform child = transform.GetChild(i);
            child.Translate(Vector3.left*Time.deltaTime);
        }
    }
    public override void triggerAction()
    {
        actionTrigger=true;
        StartCoroutine(ExecuteAfterTime(0.5f));
        // Debug.Log("Some cool stuff @" + Time.time);
    }

    
}
