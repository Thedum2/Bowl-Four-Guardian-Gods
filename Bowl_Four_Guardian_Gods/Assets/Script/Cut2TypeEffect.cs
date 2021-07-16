using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cut2TypeEffect : MonoBehaviour
{
    AudioSource EffectAudio;
    public AudioClip clip1;
    public AudioClip clip2;
    public Image cursor;
    public string targetMsg;
    public float CPS;
    public int index;
    public Text Cut1text;
    public bool isTexting;
    void Awake(){
        EffectAudio=GetComponent<AudioSource>();
        EffectAudio.clip = clip1;
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
    public void Effectplay(){
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
    public void ChangeClip(int num)
    {
        EffectAudio.clip = (num == 1 ? clip1 : clip2);
    }
}
