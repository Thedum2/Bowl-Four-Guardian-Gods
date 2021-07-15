using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cut2_Manage : MonoBehaviour
{
    public AudioClip bgmusic1;
    public AudioSource bgaudio;
    public Cut2TypeEffect talkeffect;
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;
    public Image img5;
    public Image img6;
    public Image Fadeimage;
    public Text talktext;
    public int NowTalkIndex;
    Queue<string> talkqueue;
    float time=0f;
    float F_time=5f;
    void Awake()
    {
        talkqueue=new Queue<string>();
        InputData();
        NowTalkIndex=0;
        talktext.text="";
        bgaudio=GetComponent<AudioSource>();
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
        talkqueue.Enqueue("시간이 흐르고, 남은 인간들은 요괴가 없는 지역으로 이동하고, 도망치게 돼.");
        talkqueue.Enqueue("\n\n그리고 여기, 요괴의 발이 닿지 않은 조용한 시골마을이 있어. 너무나 조용해서 \n요괴가 여기까지 찾아오겠어? 하는 그런 지역말이야.");
        talkqueue.Enqueue("\n\n그 지역엔 버려지거나 요괴에게서 혼자 도망치느라 부모를 잃은 아이들이 지내는 고아원이 있는데…");
        talkqueue.Enqueue("이 아이를 잘 봐둬. 이름은 미르야. 미르는 호기심이 많고, 정의감이 투철한 아이야.");
        talkqueue.Enqueue("\n\n장난도 많이 치고 개구지지만 심성이 착하고 남을 괴롭히지 않아서 마을 모든 사람들이 좋아해.");
    }
    
    void Changeview(int index){
        if(index==4){
            talktext.text="";
            img1.gameObject.SetActive(false);
        }
        else{
        talkeffect.SetMsg(talkqueue.Dequeue());
        }
        
    }
    IEnumerator FadeFlow(){
        talkeffect.cursorHide();
        Color alpha=Fadeimage.color;
        while(alpha.a>0.64f){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(1,0.64f,time);
            Fadeimage.color=alpha;
            Debug.Log(alpha.a);
            yield return null;
        }      
        talkeffect.cursorShow();
        yield return null;
    }
}
