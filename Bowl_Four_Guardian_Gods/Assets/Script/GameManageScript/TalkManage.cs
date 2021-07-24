using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkManage : MonoBehaviour
{    bool Istalking;
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
    

        for(int i=(nowpage-1)*4;i<nowpage*4;i++){       
        Npcnametext.text=NPCNameData[NPCindex][i];
        Talktext.text+=TalkData[NPCindex][i]+"\n";
    }
    
    

    if(!Istalking){   
    nowpage=0;
    Plray.transform.gameObject.GetComponent<NpcManage>().NPCNext();
    Teffect(NPCindex);
     }
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
            "일단 너의 상태를 스스로 확인해 보거라.",
            "",
           "",
           "",
            });
            NPCNameData.Add(200,new string[]{
            "",
            "",
           "",
           "스승",
            });

            TalkData.Add(201,new string[]{
            "네 능력치를 확인해봤느냐? ",
            "그럼 칼을 빌려줄테니 이 목각인형을 한 번 쳐보거라",
           "",
           "",
            });
            NPCNameData.Add(201,new string[]{
            "",
            "",
           "",
           "스승",
            });

             TalkData.Add(202,new string[]{
           "그럼 이번에는 강한 공격을 써서 공격해보거라.",
           "",
           "",
           ""
            });         
            NPCNameData.Add(202,new string[]{
            "",
            "",
            "",
            "스승",
            });
    }

    IEnumerator FadeFlow(){
        Color alpha=Talkimg.color;
        while(alpha.a<0.3254902f){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(0,0.3254902f,time);
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
            ControlTalk.ShowGuide("탭(tab)키를 이용해 자신의 스탯을 확인하세요!");
        }
        else if(index==201){
            ControlTalk.ShowGuide("A키를 이용해 기본 공격을 할 수 있습니다.");
        }
        else if(index==202){
            ControlTalk.ShowGuide("K키를 이용해 스킬 목록을 볼 수 있습니다.");
        }
        
    }
        
    }
    
