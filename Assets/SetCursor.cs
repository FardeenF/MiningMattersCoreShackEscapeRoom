using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{

    public Camera mainCam;
    public Texture2D OpenCursor;
    public Texture2D ClickableCursor;
    public Texture2D GrabCursor;
    public GameState gs;

    private Vector2 hotspot = new Vector2(40, 40);
    

    public void OnMouseOver()
    {
        if (gs.GetMouseOver() == false)
        {
            Cursor.SetCursor(ClickableCursor, Vector2.zero, CursorMode.Auto);
        }
        

    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(OpenCursor, Vector2.zero, CursorMode.Auto);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gs.SetMouseOver(true);
            Cursor.SetCursor(GrabCursor, Vector2.zero, CursorMode.Auto);

        }
        if (Input.GetMouseButtonUp(0))
        {
            gs.SetMouseOver(false);
            Cursor.SetCursor(OpenCursor, Vector2.zero, CursorMode.Auto);

        }

    }


}
