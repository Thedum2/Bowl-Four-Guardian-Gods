using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float m_force =0f;
    [SerializeField] Vector3 m_offset=Vector3.zero;

    Quaternion m_originRot;
    void Start()
    {
        m_originRot=transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SkillShoot(){
        StartCoroutine(ShakeCoroutine());
        Invoke("Stop",0.3f);
    }
    IEnumerator ShakeCoroutine(){
        Vector3 t_originEuler=transform.eulerAngles;
        while(true){
            float t_rotx=Random.Range(-m_offset.x,m_offset.x);
            float t_roty=Random.Range(-m_offset.y,m_offset.y);
            float t_rotz=Random.Range(-m_offset.z,m_offset.z);

            Vector3 t_randonRot=t_originEuler+new Vector3(t_rotx,t_roty,t_rotz);
            Quaternion t_rot=Quaternion.Euler(t_randonRot);

            while(Quaternion.Angle(transform.rotation,t_rot)>0.1f){
                transform.rotation=Quaternion.RotateTowards(transform.rotation,t_rot,m_force*Time.deltaTime);
                yield return null;
            }
            yield return null;
        }

    }
    IEnumerator Reset(){
        while(Quaternion.Angle(transform.rotation,m_originRot)>0f){
            transform.rotation=Quaternion.RotateTowards(transform.rotation,m_originRot,m_force*Time.deltaTime); 
            yield return null;
        }
    }
    void Stop(){
        StopAllCoroutines();
        StartCoroutine(Reset());
    }
}
