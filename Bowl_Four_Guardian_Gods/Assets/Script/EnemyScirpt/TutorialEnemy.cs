using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public double HP;
    public float MTime;
    public float Enemypower;
    SpriteRenderer EnemySpr;
    Rigidbody2D EnemyRig;
    Animator EnemyAni;
    BoxCollider2D EnemyCol;
    void Awake()
    {
        EnemySpr=GetComponent<SpriteRenderer>();
        EnemyCol=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float Playerpower){
        HP-=Playerpower;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name=="AttackPos"||other.name=="crossed1(Clone)"){
            TakeDamage(other.transform.GetComponent<PlayerAttack>().playerSt.AttackPower);
            EnemyHitAni();     
        }
        
    }
    void ToFirst(){
            gameObject.layer=9;
            EnemySpr.color=Color.white;
    }
   public void EnemyHitAni(){
            gameObject.layer=10;
            EnemySpr.color=new Color(1,0,0,1);
            Invoke("ToFirst",MTime);
            }
    }
