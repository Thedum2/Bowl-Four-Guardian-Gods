using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cut1TypeEffect : MonoBehaviour
{
    AudioSource EffectAudio;
    public Image cursor;
    public string targetMsg;
    public float CPS;
    public int index;
    public Text Cut1text;
    public bool isTexting;
    void Awake(){
        EffectAudio=GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        targetMsg=msg;
        EffectStart();
    }

    void EffectStart()
    {
        cursorHide();
        index=0;
        Invoke("Effecting",1/CPS);
        Invoke("Effectplay",1/CPS);
    }
    void Effecting()
    {
        if(index==targetMsg.Length){
            EffectEnd();
            return;
        }

        Cut1text.text+=targetMsg[index];
        index++;
        
        Invoke("Effecting",1/CPS);
    }
    void EffectEnd()
    {
        cursorShow();
        EffectAudio.Stop();
    }
    void Effectplay(){
        EffectAudio.Play();
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
