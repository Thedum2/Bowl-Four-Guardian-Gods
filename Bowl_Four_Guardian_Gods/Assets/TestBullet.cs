using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Invoke("Destroy",2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right*speed*Time.deltaTime);
    }
    void Destroy(){
        Destroy(gameObject);
    }
}
