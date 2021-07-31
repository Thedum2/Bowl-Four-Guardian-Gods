using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkill : MonoBehaviour
{
    public Transform PlayerTran;
    public Rigidbody2D Playerrigid;
    public Animator PlayerAni;
    public SpriteRenderer PlayerSpr; 
    public GameObject BulletTest; 
    public Transform BulletPos;  
    AudioSource BasicAudio;
    public AudioClip Clip1;
    public AudioClip Clip2;
    public float BulletCool; 
    public float BulletCoolTime; 
    public float Flashpower;  
    public float FlashCool;  
    public float FlashCoolTime;  
    public CameraShake Cmshake;
    public PlayerState PlayerSt;
    void Awake()
    {
        BasicAudio=GetComponent<AudioSource>();
        FlashCool=0;
    }
    void Update()
    {
        
    }
     public void ShootSkill(int index){
        switch(index){
            case 0:    
            Basic1();
            break;
            case 1:
            Basic2();  
            break;
            default:
            break;
        }
     }
    void Basic1(){
    if(FlashCool==0&&PlayerSt.SkillPoint>0){    

        PlayerSt.SkillPoint--;

            BasicAudio.clip=Clip1;
            BasicAudio.Play();

            PlayerAni.SetTrigger("IsFlash"); 
            FlashCool=FlashCoolTime;
            FlashcoolReturn();
            RaycastHit2D Flashray;

            if(PlayerSpr.flipX==false){
            Flashray= Physics2D.Raycast(Playerrigid.position, Vector3.right, Flashpower+2, LayerMask.GetMask("Ground"));
            Debug.DrawRay(Playerrigid.position, Vector3.right, new Color(0, 1, 0));
            //Debug.Log(Flashray.collider.name);
            if(Flashray.collider==null)
            PlayerTran.position=new Vector3(PlayerTran.position.x+Flashpower,PlayerTran.position.y,PlayerTran.position.z);
            }
            else{
            Flashray= Physics2D.Raycast(Playerrigid.position, Vector3.left, Flashpower+2, LayerMask.GetMask("Ground"));
            Debug.DrawRay(Playerrigid.position, Vector3.left, new Color(0, 1, 0));
            //Debug.Log(Flashray.collider.name);
            if(Flashray.collider==null)
            PlayerTran.position=new Vector3(PlayerTran.position.x-Flashpower,PlayerTran.position.y,PlayerTran.position.z);
            }
        }
    }
    void Basic2(){
        if(BulletCool==0&&PlayerSt.SkillPoint>0){
            
        PlayerSt.SkillPoint--;
            Cmshake.SkillShoot();
            BasicAudio.clip=Clip2;
            BasicAudio.Play(); 
            BulletCool=BulletCoolTime;
            BulletcoolReturn();
            Instantiate(BulletTest,BulletPos.position,PlayerTran.rotation);
        }
    }
    void FlashcoolReturn(){
        if(FlashCool==0)
        return;

        FlashCool--;
        Invoke("FlashcoolReturn",1);
    }
        void BulletcoolReturn(){
            if(BulletCool==0)
        return;

        BulletCool--;
        Invoke("BulletcoolReturn",1);
    }
}
