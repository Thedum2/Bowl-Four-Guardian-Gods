using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBossBullet : MonoBehaviour
{

    public float BulletDamage;
    public float speed;
    SpriteRenderer BulletSpr;
    AudioSource bulletaudio;
    
    void Start()
    {
        BulletSpr=GetComponent<SpriteRenderer>();
        bulletaudio=GetComponent<AudioSource>();
        int f=Random.Range(-1,1);
        if(f==-1)
        BulletSpr.flipX=true;
        else
        BulletSpr.flipX=false;
        bulletaudio.Play();
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(BulletSpr.flipX)
        transform.Translate(transform.right*speed*Time.deltaTime);
        else
        transform.Translate(transform.right*-speed*Time.deltaTime);
    }
    void Destroy(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer==6)
            Destroy();
       if(other.tag=="Player"){
            Destroy();
        }
    }
}
