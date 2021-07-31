using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public float HP;
    public float HpRegen;
    public float MaxHp;
    public float AttackPower;
    public float Defense;
    public float Speed;
    public float Dex;
    public int Money;
    public int Key;
    public int SkillPoint;
    public float SkillPointTime;
    public float MTime;
    public float EnemyHitPower;
    public Image HitImage;
    public CameraShake Cam;
    SpriteRenderer PlayerSpr;
    Rigidbody2D PlayerRig;
    public float time=0f;
    public float F_time;
    AudioSource PlayerAud;
    public int HealPotion;
    public int ManaPotion;
    public int AttackPotion;
    public int DefensePotion;
    public int SpeedPotion;
    public int DexPotion;
    private void Awake() {
        PlayerSpr=GetComponent<SpriteRenderer>();
        PlayerRig=GetComponent<Rigidbody2D>();
        PlayerAud=GetComponent<AudioSource>();
        Invoke("HpRegenfunc",10f);
        Invoke("SkillRegenfunc",SkillPointTime);
    }
   void PlayerTakeDamage(float Value)
    {
        HP-=Value;
    }
    void HpRegenfunc(){
        
        HP+=(HP/100*HpRegen)/10;

        if(HP>MaxHp)
        HP=MaxHp;

        Invoke("HpRegenfunc",1f);
    }
    void SkillRegenfunc(){
        
        SkillPoint++;

        if(SkillPoint>5)
        SkillPoint=5;

        Invoke("SkillRegenfunc",SkillPointTime);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer==9){
            StartCoroutine(FadeIn());
            PlayerTakeDamage(other.collider.GetComponent<EnemyState>().Enemypower);
            Cam.SkillShoot();
            PlayerAud.Play();
            if(HP<=0){
                
            }
            else{
            gameObject.layer=11;
            PlayerSpr.color=new Color(1,0,0,0.5f);

            int dirc=PlayerSpr.flipX==false?-1:1;
            PlayerRig.AddForce(new Vector2(EnemyHitPower*dirc,EnemyHitPower),ForceMode2D.Impulse);

            Invoke("ReturntoFirst",MTime);
            }
        }
    }
        void ReturntoFirst(){
            gameObject.layer=3;
            PlayerSpr.color=new Color(1,1,1,1);

    }
    public int ReturnSp(){
        return SkillPoint;
    }
        IEnumerator FadeIn(){
            time=0;
        Color alpha=HitImage.color;
        while(alpha.a<0.2f){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(0,0.2f,time);
            HitImage.color=alpha;
            
            yield return null;
        }      
        time=0;
        StartCoroutine(FadeOut());
        yield return null;
    }

        IEnumerator FadeOut(){
        Color alpha=HitImage.color;
        while(alpha.a>0f){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(0.2f,0,time);
            HitImage.color=alpha;          
            yield return null;
        }      
        yield return null;
    }
}
