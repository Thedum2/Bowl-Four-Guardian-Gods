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
        talkqueue.Enqueue("\n\n시발시발개씨발~@!");
    }

    void Changeview(int index){
        if(NowTalkIndex==6)
            SceneManager.LoadScene(1);
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
    
}
