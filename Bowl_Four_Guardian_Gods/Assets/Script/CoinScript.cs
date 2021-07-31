using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int ID;
    int x;
    Rigidbody2D coinrigid;
    void Awake()
    {
        coinrigid=GetComponent<Rigidbody2D>();
        x=Random.Range(-10,10);
    coinrigid.velocity=new Vector2(x,6);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.tag=="Player"){
            if(ID==0){
            GameObject.Find("Player").GetComponent<PlayerState>().Money++;
            GameObject.Find("CoinManager").GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }
            else if(ID==1){          
            GameObject.Find("Player").GetComponent<PlayerState>().Key++;
            GameObject.Find("CoinManager").GetComponent<AudioSource>().Play();
            GameObject.Find("ControlManager").GetComponent<ConTrolManage>().ShowGuide("Key를 획득했습니다!");
                Destroy(gameObject);
            }
        }
    }
}
