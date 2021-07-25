using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillUIManage : MonoBehaviour
{
    RectTransform Rect;
    public BasicSkill BSkill;
    public Image FlashImg;
    public Text FlashTxt;
    public Image ShootImg;
    public Text ShootTxt;
    float FlashPer;
    float ShootPer;
    void Awake()
    {
        Rect=GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        FlashPer=BSkill.FlashCool/(BSkill.FlashCoolTime-1)*40;
        ShootPer=BSkill.BulletCool/(BSkill.BulletCoolTime-1)*40;
        FlashImg.rectTransform.sizeDelta=new Vector2(FlashPer*2,FlashPer*2);
        ShootImg.rectTransform.sizeDelta=new Vector2(ShootPer*2,ShootPer*2);

        if(BSkill.FlashCool!=0)
        FlashTxt.enabled=true;
        else
        FlashTxt.enabled=false;

        
        if(BSkill.BulletCool!=0)
        ShootTxt.enabled=true;
        else
        ShootTxt.enabled=false;

        FlashTxt.text=BSkill.FlashCool.ToString();
        ShootTxt.text=BSkill.BulletCool.ToString();
    }
}
