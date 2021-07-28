using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEffect : MonoBehaviour
{
    AudioSource Portalaudio;
    void Awake()
    {
        Portalaudio=GetComponent<AudioSource>();
    }

public void Porsound(){
    Portalaudio.Play();
}
    void Update()
    {
        
    }
}
