using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text MoneyText;
    public PlayerState PlayerSt;
    float HpPer=0;
    public Image StateImage; 
    public Image SKillImage; 
    public Image HpImage; 
    void Awake()
    {
    }

    // Update is called once per frame
    void Update(){
            HpPer=25+(PlayerSt.HP/PlayerSt.MaxHp*1700);
            //HPUpdate();
        

        if(Input.GetKeyDown(KeyCode.Tab))
        StateImage.gameObject.SetActive(true);
        if(Input.GetKeyUp(KeyCode.Tab))
        StateImage.gameObject.SetActive(false);
        if(Input.GetKeyDown(KeyCode.K))
        SKillImage.gameObject.SetActive(true);
        if(Input.GetKeyUp(KeyCode.K))
        SKillImage.gameObject.SetActive(false);

       MoneyText.text=PlayerSt.Money.ToString();
    }
    void HPUpdate(){
        HpImage.rectTransform.sizeDelta=new Vector2(HpPer,25);
    }

}
