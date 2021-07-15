using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cut1_Manager : MonoBehaviour
{
    public GameObject cut4;
    public AudioClip bgmusic1;
    public AudioSource bgaudio;
    public TypeEffect talkeffect;
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
        talkqueue.Enqueue("혹시 너는 사방신을 믿고 있니?");
        talkqueue.Enqueue("\n내가 재미있는 이야기를 하나 알고 있어. 들어볼래?");  
        talkqueue.Enqueue("아주 오래 전, 하늘 위 천상계에는 사방신이 존재 했어. \n백호와 주작, 청룡과 현무 말이야.");     
        talkqueue.Enqueue("\n\n그리고 인간계에는 인간이 살고 있었고, 땅 밑 깊은 곳에는\n 요괴와 마물이 사는 마계가 있었지.");     
        talkqueue.Enqueue("\n\n너도 알다시피 마계에서 가장 악하고 무서운 존재는 바로 마왕이야.\n 그, 아니 그녀는 마계를 다스리면서 더 큰 영역을 얻고 싶어했어.");     
        talkqueue.Enqueue("\n\n그래서 마왕은 자신보다 약한 존재인 인간계를 침범하고 전쟁을 일으키는 선택을 하고 말았어.");     
        talkqueue.Enqueue("그렇게 시작된 영토전쟁은 요괴들보다 약한 인간들이 계속해서 밀렸어. \n어쩌면 당연한 일이지. 이대로 가다간 지고 말거야.");
        talkqueue.Enqueue("\n\n어? 그런데 인간들이 밀리고 있을 동안 천상계에 있는 사방신은 무얼했냐고?");
        talkqueue.Enqueue("\n\n안타깝게도 인간계와 땅 밑이 연결되어 있는 마계와는 다르게 천상계는 \n홀로 동떨어졌기 때문에 인간들에게 직접적인 관여를 할 수 없었어.");
        talkqueue.Enqueue("\n\n또한 너무나도 높은 존재인 그들이 하계에 내려가면 정말로 세 구역간의\n돌이킬 수 없는 전쟁이 되기 때문에 사방신들은 섣불리 행동하지 못했어.");
        talkqueue.Enqueue("하지만 중간지점인 인간계가 함락되면 천상계도 위험할 수 있었기 때문에 \n사방신은 고민을 하기 시작했고 한 가지 대안을 생각해냈어.");
        talkqueue.Enqueue("\n\n그건 인간들에게 각 사방신의 힘을 빌려 쓸 수 있게 잠재력을 개방시키는 거야.");
        talkqueue.Enqueue("\n\n한 마디로 힘을 담을 수 있는 그릇이 큰 사람을 영웅으로 만드는 계획을 세운 거지.");
    }
    
    void Changeview(int index){
        if(index==3){
        bgaudio.clip=bgmusic1;
        bgaudio.Play();
        talktext.text="";    
        talkeffect.cursorHide();
        StartCoroutine(FadeFlow());
        }
        else if(index==8){
        talktext.text=""; 
        cut4.SetActive(false);
        }
        else if(index==13){
        talktext.text=""; 
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
