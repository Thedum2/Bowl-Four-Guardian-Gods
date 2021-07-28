using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcManage : MonoBehaviour
{
    public int NPCID;
    public string NPCName;
    public HouseManage HManage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void NPCNext(){
        NPCID++;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name=="Player" && SceneManager.GetActiveScene().name=="House")
            HManage.ShowGuide("!가 붙은 NPC와 F키를 눌러 대화할 수 있습니다.");
    }
}
