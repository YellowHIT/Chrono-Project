using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class SandClock : interactTrigger
{
    private GameObject temple;
    private GameObject light;
    private GameObject booth;
    private GameObject corridor;
    private GameObject wallLine5;
    private GameObject camera;
    private GameObject dirLight;
    private GameObject blindingLight;
    private GameObject Puzzle1;
    
    private bool isRuning;
    public override void Action()
    {
        Debug.Log("Turn off");

    
    }

    public override void triggerAction()
    {
        if(isRuning==false)
        {    
            isRuning = true;
            temple = GameObject.Find("Temple");
            light = GameObject.Find("Lamps");
            booth = GameObject.Find("Scientists booth");
            corridor = GameObject.Find("Corridor");
            wallLine5 = GameObject.Find("ToBeDeactivated");
            camera = GameObject.Find("Security Cameras");
            dirLight = GameObject.Find("Directional Light (1)");
            blindingLight = FindObject("blindingLight");
            Puzzle1 = FindObject("Puzzle 1");
            
            actionTrigger=true;
            temple.gameObject.SetActive(false); 
            light.gameObject.SetActive(false); 
            booth.gameObject.SetActive(false); 
            corridor.gameObject.SetActive(false); 
            wallLine5.gameObject.SetActive(false); 
            camera.gameObject.SetActive(false); 
            dirLight.gameObject.SetActive(false);
            
            blindingLight.gameObject.SetActive(true); 
            Puzzle1.gameObject.SetActive(true); 

            StartCoroutine(ResolveAfterTime(2.0f));

            StartCoroutine(ExecuteAfterTime(10.0f));
        }
    }
    
    public override IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Turn on");

        temple.gameObject.SetActive(true); 
        light.gameObject.SetActive(true); 
        booth.gameObject.SetActive(true); 
        corridor.gameObject.SetActive(true); 
        wallLine5.gameObject.SetActive(true); 
        camera.gameObject.SetActive(true);
        dirLight.gameObject.SetActive(true); 
        Puzzle1.gameObject.SetActive(false); 
        
        actionTrigger=false;
        
        isRuning=true;

    }
    public IEnumerator ResolveAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        blindingLight.gameObject.SetActive(false); 

    }
    public GameObject FindObject(string name)
    {
        Transform[] trs= transform.parent.GetComponentsInChildren<Transform>(true);
        foreach(Transform t in trs)
        {
            if(t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }

}
