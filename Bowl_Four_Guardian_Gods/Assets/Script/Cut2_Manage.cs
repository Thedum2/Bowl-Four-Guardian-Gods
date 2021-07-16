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
    public Image Blackimg;
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
        talkqueue.Enqueue("\n\n미르는 또래 애들과 조금 다른 취미가 있는데, 그건 고대서적 분석하기야.");
        talkqueue.Enqueue("원장님이 말해주길, 어릴 적 홀로 고아원에 나타났을 때부터 \n고대서적을 품에 끼고 있었대. \n아마 이런 천성적인 이유가 특별한 취미에 한 걸음 발을 보태지 않았을까?");
        talkqueue.Enqueue("\n\n고대서적들은 희한한 좌표들이 많이 찍혀있었고, \n미르는 해석하면서 항상 좌표들은 무엇을 뜻하는지 궁금해했어");
        talkqueue.Enqueue("\n\n하지만 너무 어려워서 성인이 되는 날까지 좌표의 의미는 알아내지 못했어.");
        talkqueue.Enqueue("몇 년 뒤, 아이가 성인이 되는 날에는 아이들의 성인식을 축하하는 파티가 열렸어. \n마을 분위기는 굉장히 들떠있었지.");
        talkqueue.Enqueue("이런, 어쩌면 좋아. 요괴들이 이 마을가지 습격을 해왔고, 주민들은 공포에 휩싸여 도망치기 시작했어.");
        talkqueue.Enqueue("미르는 도망쳤지만, 마물들이 던진 돌에 머리를 맞아 정신이 반쯤 나가버렸지.");
        talkqueue.Enqueue("이대로 죽겠다, 싶었을 때 누군가 나타나서 미르를 구해줬어. 미르는 그게 사방신이라고 생각하는 모양이야.");
        talkqueue.Enqueue("어라..?");
        talkqueue.Enqueue("\n여기는 어디지...?");



    }

    void Changeview(int index){
        if (index == 4)
        {
            talktext.text = "";
            Blackimg.gameObject.SetActive(false);
        }
        else if (index == 8)
        {
            talktext.text = "";
        }
        else if(index == 12)
        {
            talktext.text = "";
            img1.gameObject.SetActive(false);
            Blackimg.gameObject.SetActive(true);
        }
        else if(index == 14)
        {
            talktext.text = "";
            talkeffect.cursorHide();
            talkeffect.ChangeClip(2);
            talkeffect.Effectplay();
            Invoke("End", 4f);
            
        }

        else if(index == 15)
        {
            Blackimg.gameObject.SetActive(false);
        }
        else if(index == 17)
        {
            talktext.text = "";
            img2.gameObject.SetActive(false);
        }
        else if(index == 19)
        {
            talktext.text = "";
            img3.gameObject.SetActive(false);
        }
        else if(index == 21)
        {
            talktext.text = "";
            Blackimg.gameObject.SetActive(true);
        }
        else
        {
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

    void End()
    {
        talkeffect.cursorShow();
        talkeffect.ChangeClip(1);
    }
}
