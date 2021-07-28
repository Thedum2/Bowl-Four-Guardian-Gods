using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text ScriptTxt;
    public int Gold = 5;


    void Start()
    {
        Gold = int.Parse(ScriptTxt.text);
    }

    // Update is called once per frame
    public void GoldPlus()
    {
        Gold += 1;
        ScriptTxt.text = Gold.ToString();
    }
}
