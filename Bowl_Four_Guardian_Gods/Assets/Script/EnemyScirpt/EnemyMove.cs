using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{    
    Rigidbody2D enemyrigid;
    SpriteRenderer enemyspr;
    Animator enemyAni;
    public int nextmove;
    public float Invoketime;
    void Awake()
    {
       enemyrigid=GetComponent<Rigidbody2D>(); 
       enemyspr=GetComponent<SpriteRenderer>();
       enemyAni=GetComponent<Animator>();
        Invoke("Think",Invoketime);
    }
    void Update(){
    enemyrigid.velocity=new Vector2(nextmove,enemyrigid.velocity.y);     
    EnemyFlip();
    //EnemyAnimation();
    //EnemyTurn();
    }
     void Think(){
        nextmove=Random.Range(-1,2); 
        Invoke("Think",Invoketime);
    }
    void EnemyFlip(){
    if(nextmove==-1)
    enemyspr.flipX=true;
    else if(nextmove==1)
    enemyspr.flipX=false;
    }
     void EnemyTurn(){
            // Update is called once per frame
    Vector2 frontvec=new Vector2(enemyrigid.position.x+(nextmove*0.3f),enemyrigid.position.y);
    Debug.DrawRay(frontvec,Vector3.down,new Color(0,1,0));
    RaycastHit2D rayHit=
    Physics2D.Raycast(frontvec,Vector3.down,1,LayerMask.GetMask("Ground"));
    if(rayHit.collider==null){
    nextmove=-nextmove;
    CancelInvoke();
    Invoke("Think",Invoketime);    
        }
    }
    void EnemyAnimation(){
    if(nextmove==-1||nextmove==1)
    enemyAni.SetBool("EnemyWalk",true);
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="AttackPos")
            enemyAni.SetTrigger("EnemyHit");
    }
}
