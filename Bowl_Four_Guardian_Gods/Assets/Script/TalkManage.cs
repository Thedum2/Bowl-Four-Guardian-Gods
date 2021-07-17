using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManage : MonoBehaviour
{
    Dictionary<int,string[]> TalkData;
    public Text Talktext;
    public Image Talkimg;
    void Awake()
    {
        InputData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InputData(){
        TalkData=new Dictionary<int, string[]>();
        TalkData.Add(100,new string[]{
            "동해물과 백두산이",
            "마르고 닳도록 하느님이",
            "보우하사 우리나라 만세",
            "무궁화 삼천리 화려강산",
            "대한사람 대한으로 길이 보전하세"
            });
    }
    public void Talk(GameObject Scanobject){

    }
}
