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
    Animator PlayerAni;

void Awake(){
    PlayerAni=GetComponent<Animator>();
}
    void Update()
    {       
        PlayerAttack();
        //PlayerActiveSkill();
        PlayerBasicSkill();
    }
    void PlayerAttack(){
            if(Input.GetKeyDown(KeyCode.A))
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
        if(Input.GetKeyDown(KeyCode.S)){
            Playeractive.ShootSkill(BasicSkill[0]);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            Playeractive.ShootSkill(BasicSkill[1]);     
        }
    }
}
