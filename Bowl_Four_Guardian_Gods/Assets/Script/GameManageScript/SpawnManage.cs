using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage : MonoBehaviour
{
    public float spawntime;
    public float curTime;
    public int EnemyCount;
    public int MaxCount;
    public Transform[] spawnPoints;
    public GameObject Enemy;
    public static SpawnManage _instance;
    void Start()
    {
        _instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        if(curTime>=spawntime&& EnemyCount<MaxCount){
            int x=Random.Range(0,spawnPoints.Length);
            SpawnMonster(x);
        }
     
        curTime+=Time.deltaTime;
    }
    void SpawnMonster(int point){
        Instantiate(Enemy,spawnPoints[point]);
        EnemyCount++;
        curTime=0;
    }
}
