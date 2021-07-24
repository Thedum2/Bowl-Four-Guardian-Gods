using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public double HP;
    public double HpRegen;
    public double MaxHp;
    public double AttackPower;
    public double Defense;
    public double Speed;
    public double Dex;
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
