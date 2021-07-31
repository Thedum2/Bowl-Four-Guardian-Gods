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
    enemyrigid.velocity=new Vector2(nextmove*2,enemyrigid.velocity.y);     
    EnemyFlip();
    //EnemyAnimation();
    EnemyTurn();
    }
     void Think(){
        nextmove=Random.Range(-1,2); 
        Invoke("Think",Invoketime);
    }
    void EnemyFlip(){
    if(nextmove==-1)
    enemyspr.flipX=false;
    else if(nextmove==1)
    enemyspr.flipX=true;
    }
     void EnemyTurn(){
            // Update is called once per frame
    Vector2 frontvec=new Vector2(enemyrigid.position.x+(nextmove*0.6f),enemyrigid.position.y);
    Debug.DrawRay(frontvec,Vector3.down*3,new Color(0,1,0));
    RaycastHit2D rayHit=
    Physics2D.Raycast(frontvec,Vector3.down,3,LayerMask.GetMask("Ground"));
    if(rayHit.collider==null){
    nextmove=-nextmove;
    Cancle();   
        }
    }

public void Cancle(){
    CancelInvoke();

    if(GameObject.Find("Player").transform.position.x>transform.position.x)
    nextmove=1;
    else
    nextmove=-1;
    Invoke("Think",Invoketime);   
}
}
