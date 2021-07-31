using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalManage : MonoBehaviour
{
    public GameObject Boss1;
    public PlayerMove PlayerPortal;
    public int ToPortalID;
    public HouseManage HManage;
    public ConTrolManage CManage;
    public PortalEffect porsound;
    Animator DoorAni;
    public Image BlackImg;
    public float time=0f;
        public float F_time;
    void Awake()
    {
        DoorAni=GetComponent<Animator>();
    }
private void OnTriggerEnter2D(Collider2D other) {
    
    if(other.name=="Player"){
    if(ToPortalID==-1){
        HManage.ShowGuide("아직 개방되지 않았습니다.");
    }
    else if(ToPortalID==-2){ 
        if(GameObject.Find("Player").GetComponent<PlayerState>().Key<5)
        CManage.ShowGuide("Key가"+(5-GameObject.Find("Player").GetComponent<PlayerState>().Key).ToString()+"개 더 필요합니다!");
        else{
            GameObject.Find("Player").GetComponent<PlayerState>().Key=  GameObject.Find("Player").GetComponent<PlayerState>().Key-5; 
            
            ToPortalID=39;   
            porsound.Porsound();
            DoorAni.SetTrigger("DoorOpen");
            StartCoroutine(FadeOUT()); 
            Boss1.SetActive(true);      
        }
    }
     else if(ToPortalID==-3){ 
        if(GameObject.Find("Player").GetComponent<PlayerState>().Key<20)
        CManage.ShowGuide("Key가"+(20-GameObject.Find("Player").GetComponent<PlayerState>().Key).ToString()+"개 더 필요합니다!");
        else{
            GameObject.Find("Player").GetComponent<PlayerState>().Key=  GameObject.Find("Player").GetComponent<PlayerState>().Key-20; 
            
            ToPortalID=41;   
            porsound.Porsound();
            DoorAni.SetTrigger("DoorOpen");
            StartCoroutine(FadeOUT()); 
            Boss1.SetActive(true);      
        }
    }
    else{
            if(ToPortalID>0){
        porsound.Porsound();
            DoorAni.SetTrigger("DoorOpen");
            StartCoroutine(FadeOUT());
            }
    }
    }
    
}
    IEnumerator FadeOUT(){
        Color alpha=BlackImg.color;
        while(alpha.a<1f){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(0,1f,time);
            BlackImg.color=alpha;
            Debug.Log(alpha.a);
            yield return null;
        }      
        PlayerPortal.PortalMove(GameObject.Find("Portal"+ToPortalID.ToString()+"Point"));
        time=0;
        Invoke("Move",1f);
        yield return null;
    }
    IEnumerator FadeShow(){
        Color alpha=BlackImg.color;
        while(alpha.a>0){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(1,0f,time);
            BlackImg.color=alpha;
            Debug.Log(alpha.a);
            yield return null;
        }      
        time=0;
        yield return null;
    }

    void Move(){
            StartCoroutine(FadeShow());
    }
}
