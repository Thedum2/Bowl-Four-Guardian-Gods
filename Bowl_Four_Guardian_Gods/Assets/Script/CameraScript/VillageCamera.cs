using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageCamera : MonoBehaviour
{
    public float Camx;
    float timein=0f;
    public float F_time;
    

    // Update is called once per frame
    void Update()
    {
        if(Camx<=173.9f){
        timein=0f;
        StartCoroutine(CamFlowIn());
        }            
    }
    IEnumerator CamFlowIn(){
        while(Camx<286.1f){
            timein+=Time.deltaTime/F_time;
            Camx=Mathf.Lerp(173.9f,286.1f,timein);
            transform.position=new Vector2(Camx,transform.position.y); 
            yield return null;
        }      
        yield return null;
    }

}
