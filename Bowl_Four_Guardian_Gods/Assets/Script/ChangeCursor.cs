using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] public Texture2D CursorImg;
    void Start()
    {
        Cursor.SetCursor(CursorImg,Vector2.zero,CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
