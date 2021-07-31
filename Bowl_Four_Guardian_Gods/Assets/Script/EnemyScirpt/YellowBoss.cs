using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBoss : MonoBehaviour
{
    public Transform Player;
    public GameObject Hpfill;
    public GameObject Bul;
    public Transform[] pos;
    SpriteRenderer bossspr;
    Rigidbody2D rigid;
    EnemyState Hpstate;
    public float hpmax;
    public float hpnow;
    public float hpper;
    public float scale;
    public float time=0f;
    public float F_time;
    public int count;
    void Start()
    {count=0;
        rigid=GetComponent<Rigidbody2D>();
        bossspr=GetComponent<SpriteRenderer>();
        Hpstate=GetComponent<EnemyState>();
        hpmax=Hpstate.HP;
        scale=Hpfill.transform.localScale.x;
        Invoke("Pattern",7f);
    }
    void Pattern(){
        int x=Random.Range(0,2);
        if(x==0)
        Pat1();
        else
        Pat2();

        Invoke("Pattern",7f);
    }
    // Update is called once per frame
    void Update()
    {

        hpnow=Hpstate.HP;
        hpper=hpnow/hpmax;
        Hpfill.transform.localScale=new Vector3(hpper*10,Hpfill.transform.localScale.y,Hpfill.transform.localScale.z);
    }
    void Pat1(){
        StartCoroutine(FadeOut());
    }    
    void Pat2(){
         Shoot();
    }
void Shoot(){
    count++;
    int x=Random.Range(0,6);
    Instantiate(Bul,pos[x].position,pos[x].rotation);
    if(count<7)
    Invoke("Shoot",0.3f);
    else
    count=0;
}
     IEnumerator FadeOut(){
         rigid.bodyType=RigidbodyType2D.Static;
        Color alpha=bossspr.color;
        time=0;
        while(alpha.a>0f){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(1,0,time);
            bossspr.color=alpha;
            Debug.Log(alpha.a);
            yield return null;
        }      

        transform.position=new Vector3(Player.position.x,Player.position.y+5,Player.position.z);
        time=0;
        StartCoroutine(FadeShow());
        yield return null;
    }
    IEnumerator FadeShow(){
        Color alpha=bossspr.color;
        while(alpha.a<1f){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(0,1,time);
            bossspr.color=alpha;
            Debug.Log(alpha.a);
            yield return null;
        }      
         rigid.bodyType=RigidbodyType2D.Dynamic;
        GameObject.Find("Camera").GetComponent<CameraShake>().SkillShoot();
        yield return null;
    }
}
