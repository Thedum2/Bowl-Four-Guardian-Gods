using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTalk : MonoBehaviour
{
    public TalkManage PlayerTalkManager;
    public int NPCindex;
    public string NPCname;
    Rigidbody2D Playerrigid;
    SpriteRenderer PlayerSpr;
    RaycastHit2D rayHit;
    void Awake()
    {
        Playerrigid=GetComponent<Rigidbody2D>();
        PlayerSpr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!PlayerSpr.flipX){
        Debug.DrawRay(Playerrigid.position, Vector3.right*2, new Color(0, 1, 0));
        rayHit = Physics2D.Raycast(Playerrigid.position, Vector3.right, 2 , LayerMask.GetMask("NPC"));           
        }  
        else{
        Debug.DrawRay(Playerrigid.position, Vector3.left*2, new Color(0, 1, 0));
        rayHit = Physics2D.Raycast(Playerrigid.position, Vector3.left, 2 , LayerMask.GetMask("NPC"));           
        }
        if(rayHit.collider!=null){
        NPCindex=rayHit.transform.gameObject.GetComponent<NpcManage>().NPCID;
        NPCname=rayHit.transform.gameObject.GetComponent<NpcManage>().NPCName;
        if(Input.GetKeyDown(KeyCode.X)){
            PlayerTalkManager.Talk(NPCindex,NPCname,rayHit);
        }
        }

    }
}
