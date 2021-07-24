using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    Animator playerani;
    void Awake()
    {
        playerani=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
             gameObject.SetActive(true);           
            playerani.SetTrigger("Attack");
        }
    
        
    }
}
