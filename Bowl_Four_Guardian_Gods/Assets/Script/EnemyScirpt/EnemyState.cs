using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public double HP;
    public float MTime;
    public float Enemypower;
    SpriteRenderer EnemySpr;
    Rigidbody2D EnemyRig;
    Animator EnemyAni;
    Collider2D EnemyCol;
    void Awake()
    {
        EnemySpr=GetComponent<SpriteRenderer>();
        EnemyRig=GetComponent<Rigidbody2D>();
        EnemyAni=GetComponent<Animator>();  
        EnemyCol=GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float Playerpower){
        HP-=Playerpower;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name=="AttackPos"){
            TakeDamage(other.transform.GetComponent<PlayerAttack>().playerSt.AttackPower);
            EnemyHitAni();     
        }
    }
    void ToFirst(){
            gameObject.layer=9;
            EnemySpr.color=Color.white;
    }
    void Dead(){
        EnemyAni.SetTrigger("IsDead");
        EnemyCol.enabled=false;
        Invoke("EnemyDestroy",1.05f);
    }
    void EnemyDestroy(){
        SpawnManage._instance.EnemyCount--;
        Destroy(gameObject);
    }
   public void EnemyHitAni(){
            if(HP<=0)
            Dead();
            else{
            EnemyRig.AddForce(new Vector2(10,5),ForceMode2D.Impulse);
            gameObject.layer=10;
            EnemySpr.color=new Color(1,0,0,0.3f);
            Invoke("ToFirst",MTime);
            }
    }
}
