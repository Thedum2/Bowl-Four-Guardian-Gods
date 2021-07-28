using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkManage : MonoBehaviour
{  
    bool Istalking;
    Dictionary<int,string[]> TalkData;
    Dictionary<int,string[]> NPCNameData;
    public HouseManage HouseTalk;
    public ConTrolManage ControlTalk;
    public PlayerMove plmov;
    public PlayerTalk pltal;
    public Text Talktext;
    public Image Talkimg;
    public Text Npcnametext;
    public int talkpage;
    public int nowpage;
    public float time=0f;
    public float F_time;
    public string targetMsg;
    public int index;
    public bool isTexting;
    public Image cursor;
        public float CPS;

    void Awake()
    {
        Talktext.text="";
        TalkData=new Dictionary<int, string[]>();
        NPCNameData=new Dictionary<int, string[]>();
        InputData();
        nowpage=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Talk(int NPCindex,RaycastHit2D Plray){
        if(!isTexting && TalkData[NPCindex]!=null){
    if(nowpage==talkpage && Istalking){
    Istalking=false;
    nowpage=0;
        Talkimg.color=new Color(0,0,0,0);
    }
    else{
    Talktext.text="";
    Istalking=true;
    StartCoroutine(FadeFlow());
    }
    Talkimg.gameObject.SetActive(Istalking);

    talkpage=TalkData[NPCindex].Length/4;
    if(TalkData[NPCindex].Length%4>0)
    talkpage++;

    nowpage++;
    targetMsg="";
        for(int i=(nowpage-1)*4;i<nowpage*4;i++){       
        Npcnametext.text=NPCNameData[NPCindex][i];
        targetMsg+=TalkData[NPCindex][i]+"\n";
    }

        EffectStart();
    

    if(!Istalking){   
    nowpage=0;
    Plray.transform.gameObject.GetComponent<NpcManage>().NPCNext();
    Teffect(NPCindex);
     }
    }
    }



     void EffectStart()
    {
        cursorHide();
        index=0;
        Invoke("Effecting",1/CPS);
    }
    void Effecting()
    {
        if(index==targetMsg.Length){
            EffectEnd();
            return;
    }

         Talktext.text+=targetMsg[index];
        index++;
        
        Invoke("Effecting",1/CPS);
    }
    void EffectEnd()
    {
        cursorShow();
    }

    void InputData(){
             TalkData.Add(100,new string[]{
            "여기는...어디죠?",
            "",
           "",
           "",
           "여긴 내 집이다. 마을 근처에 쓰러져 있더구나",
            "",
           "",
           "",
           "(마물들에게 당한건가......)",
            "",
           "",
           "",          
           "마을..마을은 어떻게 됐나요...?",
            "",
           "",
           "",          
           "...........",
            "",
           "",
           "",          
           "마을은...이미 마물들에게.....",
            "가보지 않는 편이 좋을거야.",
           "",
           "",          
           "저는 가봐야겠어요!",
            "",
           "",
           ""
            });
            NPCNameData.Add(100,new string[]{
            "",
            "",
            "",
            "미르",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "미르",
            "",
            "",
           "",
           "미르",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "미르"
            });

            TalkData. Add(200,new string[]{
            "원래 이곳은 마물들이 잘 오지 않는 지역이였어",
            "",
           "",
           "",
           ".........",
            "",
           "",
           "",
           "살아있는 사람은....더이상 없는 건가요...?",
            "",
           "",
           "",
           "안타깝지만, 그렇다네.",
            "",
           "",
           "",
           "왜....도데체 왜 제가 이런 일을 당해야 하죠?",
            "",
           "",
           "",
           "인간은, ",
            "",
           "",
           "",
           "인간은, 나약하기 때문이란다....",
            "",
           "",
           "",
           "그날 이후로, 인간은 마물에게서 도망쳐 살 수 밖에 없었어.",
            "",
           "",
           "",
           "하지만 사방신은.....더 이상 ",
            "",
           "",
           "",
           "인간에게 응답하지 않았지...",
            "",
           "",
           "",
           "이제, 어쩔셈이니?",
            "",
           "",
           "",
           "마물들을 모조리 죽이고...마을 사람들의 복수를 하겠어요...",
            "",
           "",
           "",
           "자신감 만으로는 해결 할 수 없어, 내가 도와주마",
            "",
           "",
           "",
           "준비가 되면 밖으로 나오거라",
            "",
           "",
           ""
            });
            NPCNameData.Add(200,new string[]{
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "미르",
            "",
            "",
           "",
           "미르",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "미르",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "미르",
            "",
            "",
           "",
           "스승",
            "",
            "",
           "",
           "스승"
            });

            TalkData. Add(300,new string[]{
            "일단 너의 상태를 스스로 확인해 보거라.",
            "",
           "",
           "",
            });
            NPCNameData.Add(300,new string[]{
            "",
            "",
           "",
           "스승",
            });

            TalkData.Add(301,new string[]{
            "네 능력치를 확인해봤느냐? ",
            "그럼 칼을 빌려줄테니 이 목각인형을 한 번 쳐보거라",
           "",
           "",
            });
            NPCNameData.Add(301,new string[]{
            "",
            "",
           "",
           "스승",
            });

             TalkData.Add(302,new string[]{
           "그럼 이번에는 강한 공격을 써서 공격해보거라.",
           "",
           "",
           ""
            });         
            NPCNameData.Add(302,new string[]{
            "",
            "",
            "",
            "스승",
            });
            
             TalkData.Add(303,new string[]{
           "오늘은 이만하면 된 거 같구나.",
           "내일 다시 하도록 하자.",
           "",
           ""
            });         
            NPCNameData.Add(303,new string[]{
            "",
            "",
            "",
            "스승",
            });
            
            TalkData.Add(304,new string[]{
           "어? 이게 뭐지?...",
           "고대문자들이...",
           "스승님께 가져가 봐야겠다.",
           ""
            });         
            NPCNameData.Add(304,new string[]{
            "",
            "",
            "",
            "미르",
            });

             TalkData.Add(1000,new string[]{
           "힘들었다...",
           "",
           "",
           "",
           "언젠가는 꼭....",
           "",
           "",
           "",
           "마물을.....",
           "",
           "",
           "",
           "미르는 모든 마물에 대한 복수심으로",
           "매일 매일 훈련을 계속 했다.",
           "",
           "",
           "시간은, 흐르고 흘러,",
           "마물이 마을을 습격한지도 3년이 지났다.",
           "",
           "",
           "그러던 어느 날,",
           "",
           "",
           "",
           "미르는 집에서 이상한 지도 하나를 발견하게 된다.",
           "",
           "",
           ""
            });         
            NPCNameData.Add(1000,new string[]{
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "미르"
            });
             TalkData.Add(305,new string[]{
           "스승님 이 지도가 뭔지 아세요? 바로 앞 책장 틈에서 발견했어요.",
           "",
           "",
           "",
           "이 지도 말이냐..? 혹시 여기에 써있는 게 무슨 말인지는 알고 있느냐?",
           "",
           "",
           "",
           "고대문자인건 알겠는데 무슨 뜻인지는..",
           "",
           "",
           "",
           "고대문자인지는 아는구나.",
           "그래, 현재 이걸 아는 사람은 거의 없을게다.",
           "여기에 적힌 말은 고대 유적. 과거 인간들이 영토 전쟁에서 잠시 이겼을 때 ",
           "도움을 준 천계의 신을 모셨다는 신당의 위치를 가리키는 것이지.",
           "전쟁이 다시 일어나고 신당이 무너져 두 번 다시 가보지 못했는데...",
           "",
           "",
           "",
           "스승님 혹시... 이곳으로 가면 영토전쟁에서 이겼을 때의 흔적이나 기록을 얻을 수 있지 않을까요..?",
           "",
           "",
           "",
           "설마... 여길 찾아갈 생각을 하는 건 아니겠지, 미르? ",
           "여기에 마물이 터를 잡았을지는 아니면 갑작스레 나와서 공격할지는 모르는 일이야",
           "",
           "",
           "저도 이젠 산 중턱에 침범하는 마물은 여럿 처리했어요. ",
           "그 정도는 괜찮을 거예요. 그리고 저도 언제까지 이곳에만 있을 수는 없잖아요. ",
           "강해지기 위해 수많은 노력을 했고, 이젠 직접 움직일 때도 됐다고 봐요",
           "",
           "네가 정 가고 싶다면 말리진 않으마. 하지만...",
           "",
           "",
           "",
           "알아요, 스승님. 저 정말 조심할게요. 바로 출발하지도 않을 거예요. ",
           "일주일동안 준비 단단히 해서 갈게요. 믿어주세요.",
           "",
           "",
           "그래. 알았다. 걱정이 되지만 언제까지고 너를 여기에 둘 수는 없는 노릇이지.",
           "",
           "",
           ""
            });         
            NPCNameData.Add(305,new string[]{
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "스승",
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "스승",
            "",
            "",
            "",
            "스승",
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "스승",
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "스승",
            "",
            "",
            "",
            "미르",
            "",
            "",
            "",
            "스승"
            });
    }

    IEnumerator FadeFlow(){
        Color alpha=Talkimg.color;
        while(alpha.a<0.7f){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(0,0.7f,time);
            Talkimg.color=alpha;
            Debug.Log(alpha.a);
            yield return null;
        }      
        yield return null;
    }
    
    void Teffect(int index){
        if(index==100){
            HouseTalk.SceneClose();
        }
        else if(index==200){
            GameObject.Find("Portal6").GetComponent<PortalManage>().ToPortalID=7;
            GameObject.Find("HOUSENPC").GetComponent<NpcManage>().NPCID=305;
            GameObject.Find("HOUSENPC").GetComponent<SpriteRenderer>().enabled=false;
            GameObject.Find("PlayerIsQuest").GetComponent<SpriteRenderer>().enabled=false;
        }
        else if(index==300){
            ControlTalk.ShowGuide("탭(tab)키를 이용해 자신의 스탯을 확인하세요!");
            GameObject.Find("UIManager").GetComponent<SkillUIManage>().enabled=true;
            GameObject.Find("UIManager").GetComponent<UIScript>().enabled=true;
            
        }
        else if(index==301){
            ControlTalk.ShowGuide("A키를 이용해 기본 공격을 할 수 있습니다.");
            GameObject.Find("Player").GetComponent<PlayerSkill>().enabled=true;
            GameObject.Find("AttackPos").GetComponent<PlayerAttack>().enabled=true;       
            GameObject.Find("OUTNPC").transform.position=new Vector2(197.63f,55.16f);

        }
        else if(index==302){
            ControlTalk.ShowGuide("K키를 이용해 스킬 목록을 볼 수 있습니다.");
        }      
        else if(index==303){
            GameObject.Find("OUTNPC").gameObject.SetActive(false);
            GameObject.Find("BedIsQuest").GetComponent<SpriteRenderer>().enabled=true;
            GameObject.Find("PlayerBed").GetComponent<NpcManage>().NPCID=1000;
                
        }
        else if(index==1000){
            GameObject.Find("BedIsQuest").GetComponent<SpriteRenderer>().enabled=false;
            GameObject.Find("PlayerBook").GetComponent<NpcManage>().NPCID=304;
            GameObject.Find("BookIsQuest").GetComponent<SpriteRenderer>().enabled=true;
        }
        else if(index==304){
            GameObject.Find("BookIsQuest").GetComponent<SpriteRenderer>().enabled=false;
            GameObject.Find("HOUSENPC").GetComponent<SpriteRenderer>().enabled=true;
            GameObject.Find("PlayerIsQuest").GetComponent<SpriteRenderer>().enabled=true;
        }
        
    }
        public void cursorHide(){
            isTexting=true;
        cursor.gameObject.SetActive(false);
    }
        public void cursorShow(){
            isTexting=false;
        cursor.gameObject.SetActive(true);
    }
        
    }
    
