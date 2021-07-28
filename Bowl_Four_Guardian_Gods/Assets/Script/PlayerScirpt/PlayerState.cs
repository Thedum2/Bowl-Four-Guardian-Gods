using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float MTime;
    public float EnemyHitPower;
    SpriteRenderer PlayerSpr;
    Rigidbody2D PlayerRig;
    private void Awake() {
        PlayerSpr=GetComponent<SpriteRenderer>();
        PlayerRig=GetComponent<Rigidbody2D>();
        Invoke("HpRegenfunc",10f);
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
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer==9){
            PlayerTakeDamage(other.collider.GetComponent<EnemyState>().Enemypower);
            if(HP<=0){
                PlayerDead();
            }
            else{
            gameObject.layer=11;
            PlayerSpr.color=new Color(1,0.7f,0,1);

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
    void PlayerDead(){

    }

}
