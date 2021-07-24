using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CapsuleCollider2D PosCollider;
    AudioSource playersource;
    Animator playerani;
    public PlayerState playerSt;
    
    void Awake()
    {
        PosCollider=GetComponent<CapsuleCollider2D>();
        playerani=GetComponent<Animator>();
        playersource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            CancelInvoke("Exit");
            PosCollider.enabled=true;
             playersource.Play();           
            playerani.SetTrigger("Attack");
            Invoke("Exit",0.10f);
            
        }   
    }
    void Exit(){
        PosCollider.enabled=false;
    }
}
