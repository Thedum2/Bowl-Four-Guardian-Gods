using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConTrolManage : MonoBehaviour
{

    public Image GuideImg;
    public Text GuideTxt;
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowGuide(string txt){
        GuideImg.gameObject.SetActive(false);
        GuideImg.gameObject.SetActive(true);
        GuideTxt.text=txt;
    }
    }
