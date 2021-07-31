using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public float HP;
    public float MTime;
    public float Enemypower;
    public int InEnemyMoney;
    public int InEnemykey;
    public GameObject Coin;
    public GameObject Key;
    public string SpawnId;
    SpriteRenderer EnemySpr;
    Rigidbody2D EnemyRig;
    Animator EnemyAni;
    Collider2D EnemyCol;
    Rigidbody2D Playerrigid;
    EnemyMove enemyMo;
    public Animator Hitani;
    void Awake()
    {
        EnemySpr=GetComponent<SpriteRenderer>();
        EnemyRig=GetComponent<Rigidbody2D>();
        EnemyAni=GetComponent<Animator>();  
        EnemyCol=GetComponent<Collider2D>();
        Playerrigid=GetComponent<Rigidbody2D>();
        enemyMo=GetComponent<EnemyMove>();
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
            for(int i=0;i<Random.Range(1,InEnemyMoney);i++)
                Instantiate(Coin,transform.position,transform.rotation);
            for(int i=0;i<InEnemykey;i++)
                Instantiate(Key,transform.position,transform.rotation);

        Playerrigid.bodyType=RigidbodyType2D.Static;
        Invoke("EnemyDestroy",1.05f);
    }
    void EnemyDestroy(){
        if(GameObject.Find("Spawnmanager"+SpawnId)!=null)
        GameObject.Find("Spawnmanager"+SpawnId).GetComponent<SpawnManage>().EnemyCount--;
        Destroy(gameObject);
    }
   public void EnemyHitAni(){
            if(HP<=0)
            Dead();
            else{
            Hitani.SetTrigger("IsHit");
            enemyMo.Cancle();
            if(EnemySpr.flipX)
            EnemyRig.velocity=new Vector2(10,5);
            else
            EnemyRig.velocity=new Vector2(-10,5);
            gameObject.layer=10;
            EnemySpr.color=new Color(1,0,0,0.3f);
            Invoke("ToFirst",MTime);
            }
    }
}
