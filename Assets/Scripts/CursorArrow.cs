using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorArrow : MonoBehaviour
{
    public Texture2D arrow;
    void Start()
    {
        Cursor.SetCursor(arrow, Vector2.zero, CursorMode.ForceSoftware);
    }


}
