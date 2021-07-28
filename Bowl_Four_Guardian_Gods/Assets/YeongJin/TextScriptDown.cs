using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScriptDown : MonoBehaviour
{
    public Text ScriptTxt;
    public int Gold;


    void Start()
    {
        Gold = int.Parse(ScriptTxt.text);
    }

    // Update is called once per frame
    public void GoldPlus()
    {
        if (Gold > 0)
        {
            Gold -= 1;
        }
        ScriptTxt.text = Gold.ToString();
    }
}
