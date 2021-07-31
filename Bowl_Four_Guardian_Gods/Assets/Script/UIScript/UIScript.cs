using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text MoneyText;
    public Text KeyText;
    public PlayerState PlayerSt;
    
    float HpPer=0;
    public Image StateImage; 
    public Image SKillImage; 
    public Slider HpImage; 
    public Image[] SkillP;
    public Text HpText;
    public Text MANAText;
    public Text AttackText;
    public Text DefenseText;    
    public Text SpeedText;
    public Text DexText;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update(){
        TurnOnSkillp();
            HpPer=PlayerSt.HP/PlayerSt.MaxHp;
            HPUpdate();
        
        if(Input.GetKeyDown(KeyCode.Tab))
        StateImage.gameObject.SetActive(true);
        if(Input.GetKeyUp(KeyCode.Tab))
        StateImage.gameObject.SetActive(false);
        if(Input.GetKeyDown(KeyCode.K))
        SKillImage.gameObject.SetActive(true);
        if(Input.GetKeyUp(KeyCode.K))
        SKillImage.gameObject.SetActive(false);

       MoneyText.text=PlayerSt.Money.ToString();
       KeyText.text=PlayerSt.Key.ToString();
    }
    void HPUpdate(){
        HpImage.value=HpPer;
    }
    void TurnOnSkillp(){
        for(int i=0;i<PlayerSt.ReturnSp();i++)
            SkillP[i].color=Color.white;
        for(int i=PlayerSt.ReturnSp();i<=4;i++)
            SkillP[i].color=Color.black;
        HpText.text=PlayerSt.HealPotion.ToString();
        MANAText.text=PlayerSt.ManaPotion.ToString();
        AttackText.text=PlayerSt.AttackPotion.ToString();
        DefenseText.text=PlayerSt.DefensePotion.ToString();
        SpeedText.text=PlayerSt.SpeedPotion.ToString();
        DexText.text=PlayerSt.DexPotion.ToString();
    }
}
