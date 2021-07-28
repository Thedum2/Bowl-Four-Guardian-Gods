using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VillageManager : MonoBehaviour
{
    public VillageEffect talkeffect;
    public Image Blackimg;
    public Text talktext;
    public int NowTalkIndex;
    Queue<string> talkqueue;
    float time=0f;
    float V_time=3f;
    float time2=0f;
    float V_time2=6f;
    void Awake()
    {
        talkqueue=new Queue<string>();
        InputData();
        NowTalkIndex=0;
        talktext.text="";
        StartCoroutine(FadeShow());
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))&&talkeffect.isTexting==false){
        NowTalkIndex++;
        Changeview(NowTalkIndex);
        }
    }
    void InputData(){
        talkqueue.Enqueue(".......");
        talkqueue.Enqueue("\n\n........................");
        talkqueue.Enqueue("\n\n이게......뭐야......");
        talkqueue.Enqueue("\n\n다들...어디간거야?");
        talkqueue.Enqueue("\n\n마을이...왜?...");
        talkqueue.Enqueue("마을은 마물에게 침략 당했고, 남아 있는 것은 없었다.");
        talkqueue.Enqueue("\n\n마을로 돌아온 미르는 아무것도 할 수 없었다.");
        talkqueue.Enqueue("\n\n미르는 마물들에 대한 복수심으로 가득 차며....");
        talkqueue.Enqueue("\n\n그 자리에서..");
        talkqueue.Enqueue("\n\n다시 기절하고 말았다.");
    }

    void Changeview(int index){
        if(NowTalkIndex==6)
        talktext.text="";
        else if(NowTalkIndex==12){
        talktext.text="";
        StartCoroutine(FadeOut());
        }
        else
            talkeffect.SetMsg(talkqueue.Dequeue());      
    }
    
    IEnumerator FadeShow(){
        talkeffect.cursorHide();
        Color alpha=Blackimg.color;
        while(alpha.a>0.5882f){
            time+=Time.deltaTime/V_time;
            alpha.a=Mathf.Lerp(1,0.5882f,time);
            Blackimg.color=alpha;
            Debug.Log(alpha.a);
            yield return null;
        }      
        talkeffect.cursorShow();
        yield return null;
    }
    IEnumerator FadeOut(){
        talkeffect.cursorHide();
        Color alpha=Blackimg.color;
        while(alpha.a<1f){
            time2+=Time.deltaTime/V_time2;
            alpha.a=Mathf.Lerp(0.5882f,1f,time2);
            Blackimg.color=alpha;
            Debug.Log(alpha.a);
            yield return null;
        }      
        SceneManager.LoadScene(7);
        yield return null;
    }
}
