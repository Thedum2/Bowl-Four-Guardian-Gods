using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{   public float BulletDamage;
    public float speed;
    SpriteRenderer BulletSpr;
    
    void Start()
    {
        BulletSpr=GetComponent<SpriteRenderer>();
        BulletSpr.flipX=GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX;
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
        if(other.tag=="Enemy"){
            Debug.Log("!!!!!");
            other.GetComponent<EnemyState>().TakeDamage(BulletDamage);
            Destroy();
        }
    }
}
