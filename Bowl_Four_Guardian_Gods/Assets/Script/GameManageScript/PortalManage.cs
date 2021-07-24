using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalManage : MonoBehaviour
{
    public GameObject[] PortalObj;
    public PlayerMove PlayerPortal;
    public int NowPortalID;
    public int ToPortalID;
    public HouseManage HManage;
    void Awake()
    {
        
    }
private void OnTriggerEnter2D(Collider2D other) {
    if(other.name=="Player"){
        HManage.ShowGuide("↑키를 이용해 포탈을 이용할 수 있습니다.");
    }
}
    void OnTriggerStay2D(Collider2D other)
    {    
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            PlayerPortal.PortalMove(PortalObj[ToPortalID]);
        }
    }
}
