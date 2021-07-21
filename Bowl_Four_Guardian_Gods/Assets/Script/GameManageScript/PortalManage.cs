using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManage : MonoBehaviour
{
    public GameObject[] PortalObj;
    public PlayerMove PlayerPortal;
    public int NowPortalID;
    public int ToPortalID;
    void Awake()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {    
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            PlayerPortal.PortalMove(PortalObj[ToPortalID]);
        }
    }
}
