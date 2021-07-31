using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    
       public float BulletDamage;
    public float speed;
    SpriteRenderer BulletSpr;
    
    void Start()
    {
        BulletSpr=GetComponent<SpriteRenderer>();
        BulletSpr.flipX=GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX;
        BulletDamage=GameObject.Find("Player").GetComponent<PlayerState>().AttackPower*1.3f;
        Invoke("Destroy",2f);
    }

    // Update is called once per frame
    void Update()
    { 
        if(BulletSpr.flipX==false)
        transform.Translate(transform.right*speed*Time.deltaTime);
        else
        transform.Translate(transform.right*-speed*Time.deltaTime);
    }
    void Destroy(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        Debug.Log(other.name);
        Debug.Log(other.tag);

        if(other.tag=="Ground")
        Destroy();

        if(other.tag=="Enemy"){
            other.GetComponent<EnemyState>().TakeDamage(BulletDamage);
            other.GetComponent<EnemyState>().EnemyHitAni();
        }
    }
}
