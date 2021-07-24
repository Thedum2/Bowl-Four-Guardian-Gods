using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public float Flashpower;  
    public float FlashCool;  
    public bool IsCool;   
    public GameObject BulletTest; 
    public Transform BulletPos;   
    Rigidbody2D Playerrigid;
    Animator PlayerAni;
    SpriteRenderer PlayerSpr;  
    void Awake()
    {
       Playerrigid=GetComponent<Rigidbody2D>();
       PlayerAni=GetComponent<Animator>();
       PlayerSpr=GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {       
        PlayerFlash();
        PlayerAttack();
        ShootTest();
    }
     void PlayerFlash(){
        if(Input.GetKeyDown(KeyCode.C)&& !IsCool){    
            PlayerAni.SetTrigger("IsFlash"); 
            IsCool=true;
            Invoke("FlashcoolReturn",FlashCool);
            RaycastHit2D Flashray;
            if(PlayerSpr.flipX==false){
            Flashray= Physics2D.Raycast(Playerrigid.position, Vector3.right, Flashpower+2, LayerMask.GetMask("Ground"));
            Debug.DrawRay(Playerrigid.position, Vector3.right, new Color(0, 1, 0));
            //Debug.Log(Flashray.collider.name);
            if(Flashray.collider==null)
            transform.position=new Vector3(transform.position.x+Flashpower,transform.position.y,transform.position.z);
            }
            else{
            Flashray= Physics2D.Raycast(Playerrigid.position, Vector3.left, Flashpower+2, LayerMask.GetMask("Ground"));
            Debug.DrawRay(Playerrigid.position, Vector3.left, new Color(0, 1, 0));
            //Debug.Log(Flashray.collider.name);
            if(Flashray.collider==null)
            transform.position=new Vector3(transform.position.x-Flashpower,transform.position.y,transform.position.z);
            }
        }
    }
    void FlashcoolReturn(){
        IsCool=false;
    }
    void PlayerAttack(){
            if(Input.GetKeyDown(KeyCode.A))
            PlayerAni.SetTrigger("IsAttack"); 
    }
    void ShootTest(){
        if(Input.GetKeyDown(KeyCode.Q)){
            Instantiate(BulletTest,BulletPos.position,transform.rotation);
        }
    }

}
