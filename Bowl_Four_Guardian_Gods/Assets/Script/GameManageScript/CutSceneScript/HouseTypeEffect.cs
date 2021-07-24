using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseTypeEffect : MonoBehaviour
{
    public Image cursor;
    public string targetMsg;
    public float CPS;
    public int index;
    public Text Cut1text;
    public bool isTexting;
    void Awake(){
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
    }
    public void Effectplay(){
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
