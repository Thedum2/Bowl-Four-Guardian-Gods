using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManage : MonoBehaviour
{    bool Istalking;
    Dictionary<int,string[]> TalkData;
    Dictionary<int,string> NPCNameData;
    public Text Talktext;
    public Image Talkimg;
    public Text Npcnametext;
    public int talkpage;
    public int nowpage;
    void Awake()
    {
        Talktext.text="";
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
    }
    else{
    Talktext.text="";
    Istalking=true;
    }

    talkpage=TalkData[NPCindex].Length/4;
    if(TalkData[NPCindex].Length%4>0)
    talkpage++;

    nowpage++;
    
        Npcnametext.text=NPCNameData[NPCindex];

        for(int i=(nowpage-1)*4;i<nowpage*4;i++){
        Talktext.text+=TalkData[NPCindex][i]+"\n";
    }
    
    
    Talkimg.gameObject.SetActive(Istalking);

    if(!Istalking){
    nowpage=0;
    Plray.transform.gameObject.GetComponent<NpcManage>().NPCNext();
    }
    }


    void InputData(){
        TalkData=new Dictionary<int, string[]>();
        NPCNameData=new Dictionary<int, string>();

        TalkData.Add(100,new string[]{
            "일단 너의 상태를 스스로 확인해 보거라.",
            "",
           "",
           ""
            });
        NPCNameData.Add(100,"스승");

             TalkData.Add(101,new string[]{
            "네 능력치를 확인해봤느냐? 그럼 칼을 빌려줄테니 이 목각인형을 한 번 쳐보거라",
            "",
           "",
           ""
            });
        NPCNameData.Add(101,"스승");

             TalkData.Add(200,new string[]{
            "여기는...어디죠?",
            "",
           "",
           ""
            });
        NPCNameData.Add(200,"미르");

            TalkData.Add(201,new string[]{
            "여긴 내 집이다. 마을 근처에 쓰러져 있더구나",
            "",
           "",
           ""
            });
        NPCNameData.Add(201,"스승");

    }
}
