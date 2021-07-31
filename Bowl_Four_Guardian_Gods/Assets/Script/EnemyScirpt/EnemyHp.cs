using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public GameObject Hpfill;
    EnemyState Hpstate;
    public float hpmax;
    public float hpnow;
    public float hpper;
    public float scale;
    void Start()
    {
        Hpstate=GetComponent<EnemyState>();
        hpmax=Hpstate.HP;
        scale=Hpfill.transform.localScale.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        hpnow=Hpstate.HP;
        hpper=hpnow/hpmax;
        Hpfill.transform.localScale=new Vector3(hpper,Hpfill.transform.localScale.y,Hpfill.transform.localScale.z);
    }
}
