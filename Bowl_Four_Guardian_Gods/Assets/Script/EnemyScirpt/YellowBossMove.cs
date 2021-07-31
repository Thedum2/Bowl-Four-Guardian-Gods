using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBossMove : MonoBehaviour
{
    public Transform Player;
Rigidbody2D enemyrigid;
    SpriteRenderer enemyspr;
    Animator enemyAni;
    public int nextmove;
    void Awake()
    {
       enemyrigid=GetComponent<Rigidbody2D>(); 
       enemyspr=GetComponent<SpriteRenderer>();
       enemyAni=GetComponent<Animator>();
    }
    void Update(){
    Think();
    enemyrigid.velocity=new Vector2(nextmove*5,enemyrigid.velocity.y);     
    EnemyFlip();
    //EnemyAnimation();
    }
     void Think(){
         if(transform.position.x<Player.transform.position.x)
         nextmove=1;
         else
         nextmove=-1;
    }
    void EnemyFlip(){
    if(nextmove==-1)
    enemyspr.flipX=false;
    else if(nextmove==1)
    enemyspr.flipX=true;
    }

}
