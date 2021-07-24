using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HouseManage : MonoBehaviour
{    
   public Animator plani;
    public Rigidbody2D plrig;
    public PlayerMove plmov;
    public HouseTypeEffect talkeffect;
    public Image Fadeimage;
    public Image BackImage;
    public Text talktext;
    public int NowTalkIndex;
    public Image GuideImg;
    public Text GuideTxt;
    Queue<string> talkqueue;
    float time=0f;
    float F_time=5f;
    void Awake()
    {
        talkqueue=new Queue<string>();
        InputData();
        NowTalkIndex=0;
        talktext.text="";
        plani.enabled=false; 
        plmov.enabled=false;  
        plrig.bodyType=RigidbodyType2D.Static;
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
        talkqueue.Enqueue("으으......");
        talkqueue.Enqueue("\n\n여기는 어디지...?");
        talkqueue.Enqueue("\n\n누가....날...");
    }
    
    void Changeview(int index){
        if(index==4){
        plani.enabled=true; 
        plmov.enabled=true;  
        plrig.bodyType=RigidbodyType2D.Dynamic;
        Fadeimage.gameObject.SetActive(false);
        Animator guide=GuideImg.GetComponent<Animator>();
        guide.gameObject.SetActive(true);
        this.enabled=false;
        }
        else
        talkeffect.SetMsg(talkqueue.Dequeue());
        }

    public void ShowGuide(string txt){
        GuideImg.gameObject.SetActive(false);
        GuideImg.gameObject.SetActive(true);
        GuideTxt.text=txt;
    }
    public void SceneClose(){
        StartCoroutine(FadeFlow());
    }

     IEnumerator FadeFlow(){
        Color alpha=BackImage.color;
        while(alpha.a<1f){
            time+=Time.deltaTime/F_time;
            alpha.a=Mathf.Lerp(0,1f,time);
            BackImage.color=alpha;
            Debug.Log(alpha.a);
            yield return null;
        }
        SceneManager.LoadScene(6);      
        yield return null;
        
}
}

    

