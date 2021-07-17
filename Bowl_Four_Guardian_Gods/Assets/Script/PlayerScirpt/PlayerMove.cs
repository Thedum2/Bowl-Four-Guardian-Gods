using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Movepower;
    public float Maxspeed;
    public float Jumppower;  
    
    Rigidbody2D Playerrigid;
    Animator PlayerAni;
    SpriteRenderer PlayerSpr; 
    void Start()
    {
       Playerrigid=GetComponent<Rigidbody2D>();
       PlayerAni=GetComponent<Animator>();
       PlayerSpr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){
        PlayerMOVEJUMP();
    }

    void FixedUpdate() {
        PlayerHorizontalMOve();
    }

    void PlayerHorizontalMOve(){
        //Player좌우 이동
        float h=Input.GetAxisRaw("Horizontal"); 
        if(!PlayerAni.GetCurrentAnimatorStateInfo(0).IsName("PlayerFlash"))
        Playerrigid.AddForce(Vector2.right*h*Movepower,ForceMode2D.Impulse);       
    }

    void PlayerMOVEJUMP(){
        //Player 최고 속도 제한
        if(Playerrigid.velocity.x >Maxspeed)
        Playerrigid.velocity=new Vector2(Maxspeed,Playerrigid.velocity.y);
        if(Playerrigid.velocity.x <-Maxspeed)
        Playerrigid.velocity=new Vector2(-Maxspeed,Playerrigid.velocity.y);

        //플레이어 중간 감속
         if(Input.GetButtonUp("Horizontal")){
            if(Playerrigid.velocity.x>0)
            Playerrigid.velocity=new Vector2(0.1f,Playerrigid.velocity.y);
            else if(Playerrigid.velocity.x<0)
            Playerrigid.velocity=new Vector2(-0.1f,Playerrigid.velocity.y);
            }

        //Player 달리기 애니메이션
        //if(Mathf.Abs(Playerrigid.velocity.x)>0.3f)
        //    PlayerAni.SetBool("IsRun",true);
        //else
        //    PlayerAni.SetBool("IsRun",false);

        //플레이어 점프
        if(Input.GetButtonDown("Jump")&&PlayerAni.GetBool("IsJump")==false){
                PlayerAni.SetBool("IsJump",true);
                Playerrigid.AddForce(Vector2.up*Jumppower,ForceMode2D.Impulse);
        }

        //레이를 이용해 땅에 닿았는지 검사
        if(Playerrigid.velocity.y <0){
            PlayerAni.SetBool("IsFall",true);
            Debug.DrawRay(Playerrigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(Playerrigid.position, Vector3.down, 1, LayerMask.GetMask("Ground"));           
            Debug.Log(rayHit.distance);
            if (rayHit.collider != null)
                if (rayHit.distance < 1.2f){
                    PlayerAni.SetBool("IsFall",false);
                    PlayerAni.SetBool("IsJump",false);
                }
            }

        //플레이어 바향전환 시 뒤집기
        if(Playerrigid.velocity.x>=0.1f)
        PlayerSpr.flipX=false;
        else if (Playerrigid.velocity.x<=-0.1f)
        PlayerSpr.flipX=true;
    }
   
}
