using UnityEngine;
using System.Collections;

public class CursorImage: MonoBehaviour
{
    public Texture2D crossHairTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
 
    void Update()
    {
        if(!UIHandler.IsUIActive)
        {
            Cursor.SetCursor(crossHairTexture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}