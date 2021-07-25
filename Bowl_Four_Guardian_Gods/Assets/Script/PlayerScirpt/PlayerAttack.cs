using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CapsuleCollider2D PosCollider;
    AudioSource playersource;
    Animator playerani;
    public PlayerState playerSt;
    public bool IsAttackCool;
    public float AttackCool;
    public SpriteRenderer PlayerSpr;
    void Awake()
    {
        PosCollider=GetComponent<CapsuleCollider2D>();
        playerani=GetComponent<Animator>();
        playersource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)&&!IsAttackCool){
            CancelInvoke("Exit");
            IsAttackCool=true;
            PosCollider.enabled=true;
             playersource.Play();           
            playerani.SetTrigger("Attack");
            Invoke("Exit",0.10f);
            Invoke("ReturnAttackCool",AttackCool);
            
        }   
    }
    void Exit(){
        PosCollider.enabled=false;
    }
    void ReturnAttackCool(){
        IsAttackCool=false;
    }
}
