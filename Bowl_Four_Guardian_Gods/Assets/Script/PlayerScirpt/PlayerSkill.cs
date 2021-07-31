using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public int[] ActiveSkill;
    public int[] BasicSkill;
    public int[] PassiveSkill;
    public ActiveSkill Playeractive;
    public BasicSkill Playerbasic;
    public ItemSkill Playeritem;
    Animator PlayerAni;

void Awake(){
    PlayerAni=GetComponent<Animator>();
}
    void Update()
    {       
        //PlayerActiveSkill();
        PlayerBasicSkill();
        PlayerEatItem();
    }
    public void PlayerAttack(){
            PlayerAni.SetTrigger("IsAttack"); 
    }
    
    void PlayerActiveSkill(){
        if(Input.GetKeyDown(KeyCode.Q)){
            Playeractive.ShootSkill(ActiveSkill[0]);
        }
        if(Input.GetKeyDown(KeyCode.W)){
            Playeractive.ShootSkill(ActiveSkill[1]);     
        }
        if(Input.GetKeyDown(KeyCode.E)){ 
            Playeractive.ShootSkill(ActiveSkill[2]);     
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Playeractive.ShootSkill(ActiveSkill[3]);     
        }
    }
    void PlayerBasicSkill(){
        if(Input.GetKeyDown(KeyCode.S)){
            Playerbasic.ShootSkill(BasicSkill[0]);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            Playerbasic.ShootSkill(BasicSkill[1]);     
        }
    }

    void PlayerPassiveSkill(){
        
    }
    void PlayerEatItem(){
        if(Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Keypad1)){
            Playeritem.ItemEat(1);
    }
        if(Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Keypad2)){
            Playeritem.ItemEat(2);
    }
        if(Input.GetKeyDown(KeyCode.Alpha3)||Input.GetKeyDown(KeyCode.Keypad3)){
            Playeritem.ItemEat(3);
    }
        if(Input.GetKeyDown(KeyCode.Alpha4)||Input.GetKeyDown(KeyCode.Keypad4)){
            Playeritem.ItemEat(4);
    }
        if(Input.GetKeyDown(KeyCode.Alpha5)||Input.GetKeyDown(KeyCode.Keypad5)){
            Playeritem.ItemEat(5);
    }
        if(Input.GetKeyDown(KeyCode.Alpha6)||Input.GetKeyDown(KeyCode.Keypad6)){
            Playeritem.ItemEat(6);
    }
}
}
