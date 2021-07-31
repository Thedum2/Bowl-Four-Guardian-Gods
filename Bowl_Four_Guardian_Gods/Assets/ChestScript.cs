using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{   public int Hp;
    public int InChestMoney;
    public float InChestKey;
    public GameObject Coin;
    public GameObject Key;
    Animator ChestAni;
    int i;
    void Awake()
    {
        ChestAni=GetComponent<Animator>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Attack"){
            Hp--;
            Animation(Hp);
        }
    }
    void Animation(int hhpp){
        if(hhpp==0){
            ChestAni.SetBool("IsDead",true);
            for(i=0;i<InChestMoney;i++){
                Instantiate(Coin,transform.position,transform.rotation);}
            for(i=0;i<InChestKey;i++){
                Instantiate(Key,transform.position,transform.rotation);
            }
            Invoke("ChestDead",1.5f);
        }
        else{
            ChestAni.SetTrigger("ChestAttack");
        }
    }
    void ChestDead(){
        Destroy(gameObject);
    }
}
