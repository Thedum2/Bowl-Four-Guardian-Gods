using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public int UIid;
    public PlayerState PlayerSt;
    RectTransform RecT;
    float HpPer;
    void Awake()
    {
        RecT=GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(UIid){
            case 0:
            HpPer=25+(PlayerSt.HP/PlayerSt.MaxHp*1700);
            HPUpdate();
            break;
            case 1:
            default:
            break;
        }
    }
    void HPUpdate(){
        RecT.sizeDelta=new Vector2(HpPer,25);
    }
}
