using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public double HP;
    public float MTime;
    public float power;
    SpriteRenderer EnemySpr;
    Rigidbody2D EnemyRig;
    void Awake()
    {
        EnemySpr=GetComponent<SpriteRenderer>();
        EnemyRig=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDamage(double power){
        HP-=power;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name=="AttackPos"){
            EnemyRig.AddForce(new Vector2(10,5),ForceMode2D.Impulse);
            Debug.Log("EnemyHit");
            TakeDamage(other.transform.GetComponent<PlayerAttack>().playerSt.AttackPower);
            gameObject.layer=10;
            EnemySpr.color=new Color(1,0,0,0.3f);
            Invoke("ToFirst",MTime);
        }
    }
    void ToFirst(){
            gameObject.layer=9;
            EnemySpr.color=Color.white;
    }
}
