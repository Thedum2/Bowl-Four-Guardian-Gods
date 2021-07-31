using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSkill : MonoBehaviour
{
    public PlayerState playerSt;
    AudioSource Playeraud;
    public AudioClip clip1;
    void Awake()
    {
        Playeraud=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
         public void ItemEat(int index){
        switch(index){
            case 1:
            if(playerSt.HealPotion>0){ 
            playerSt.HealPotion--;
            playerSt.HP=playerSt.HP/10*12;
            EatSound();
            }
            break;
            case 2:
            if(playerSt.ManaPotion>0){ 
            playerSt.ManaPotion--;
            playerSt.SkillPoint++;
            EatSound();
            }
            break;
            default:
            break;
        }
     }
     void EatSound(){   
            Playeraud.clip=clip1;
            Playeraud.Play();
     }
}
