using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalManage : MonoBehaviour
{
    public PlayerMove PlayerPortal;
    public int ToPortalID;
    public HouseManage HManage;
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
    
    if(other.name=="Player"&&ToPortalID==-1){
        HManage.ShowGuide("아직 개방되지 않았습니다.");
    }
    else if(other.name=="Player"){
        HManage.ShowGuide("↑키를 이용해 포탈을 이용할 수 있습니다.");
    }
}
    void OnTriggerStay2D(Collider2D other)
    {    
        if(Input.GetKeyDown(KeyCode.UpArrow)){ 
        porsound.Porsound();
            DoorAni.SetTrigger("DoorOpen");
            StartCoroutine(FadeOUT());
            
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
        PlayerPortal.PortalMove(GameObject.Find("Portal"+ToPortalID.ToString()));
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
