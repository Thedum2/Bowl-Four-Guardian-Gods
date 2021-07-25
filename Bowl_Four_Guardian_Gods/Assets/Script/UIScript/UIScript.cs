using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public PlayerState PlayerSt;
    public Text MoneyText;
    public Image HpImage;
    
    float HpPer;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            HpPer=25+(PlayerSt.HP/PlayerSt.MaxHp*700);
            HPUpdate();
            MoneyText.text=PlayerSt.Money.ToString();
    }
    void HPUpdate(){
        HpImage.rectTransform.sizeDelta=new Vector2(HpPer,25);
    }
}
