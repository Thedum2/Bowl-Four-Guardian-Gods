using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CapsuleCollider2D PosCollider;
    AudioSource playersource;
    Animator playerani;
    SpriteRenderer playerSpr;
    public PlayerState playerSt;
    public PlayerSkill playerSk;
    public bool IsAttackCool;
    public float AttackCool;
    public SpriteRenderer PlayerSpr;
    void Awake()
    {
        PosCollider=GetComponent<CapsuleCollider2D>();
        playerani=GetComponent<Animator>();
        playersource=GetComponent<AudioSource>();
        playerSpr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Point();
        if(Input.GetKeyDown(KeyCode.A)&&!IsAttackCool){
            CancelInvoke("Exit");
            IsAttackCool=true;
            PosCollider.enabled=true;
            playerSpr.enabled=true;
            playerSk.PlayerAttack();
             playersource.Play();
            playerSpr.color=new Color(1,1,1,1);  
            Invoke("Exit",0.3f);
            Invoke("ReturnAttackCool",AttackCool);
            
        }   
    }
    void Exit(){
        PosCollider.enabled=false;
        playerSpr.enabled=false;
    }
    void ReturnAttackCool(){
        IsAttackCool=false;
    }
    void Point(){
       // if(PlayerSpr.flipX==true)
       // transform.position=new Vector2(-transform.position.x,transform.position.y);
    }
}
