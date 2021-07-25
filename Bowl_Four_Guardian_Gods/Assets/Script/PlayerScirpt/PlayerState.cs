using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float HP;
    public float HpRegen;
    public float MaxHp;
    public float AttackPower;
    public float Defense;
    public float Speed;
    public float Dex;
    public int Money;
    private void Awake() {
        Invoke("HpRegenfunc",10f);
    }
   void Update()
    {
        
    }
    void HpRegenfunc(){
        
        HP+=HP/100*HpRegen;

        if(HP>MaxHp)
        HP=MaxHp;
        Invoke("HpRegenfunc",10f);
    }
}
