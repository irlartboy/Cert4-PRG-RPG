using System.Collections;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public bool showDlg;
    public string[] dlgText;
    public Vector2 scr;
    public int index, optionsIndex;
    void Start()
    {

    }


    // Code version of canvas
    void OnGUI()
    {
        if (showDlg)
        {
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
            // GUI elemt of type box:
            // new rectangular position ans size
            // pos X, pos Y, size x, size y 
            // content of box
            GUI.Box(new Rect(0, 6 * scr.y, Screen.width, 3 * scr.y), dlgText[index]);
            // have a box that touches the left edge and goes to the right edge
            // and starts 2/3rds down the screen and is 1/3rd in size finishing at the bottom of the screen
            if (!(index + 1 >= dlgText.Length || index == optionsIndex))
            {
                if (GUI.Button(new Rect(14.5f * scr.x, 8f * scr.y, scr.x, 0.5f * scr.y), "Next"))
                {
                    index++;
                }
            }
            else if (index == optionsIndex)
            {
                if (GUI.Button(new Rect(12f * scr.x, 8f * scr.y, scr.x, 0.5f * scr.y), "Yes"))
                {
                    index++;
                }
                if (GUI.Button(new Rect(13f * scr.x, 8f * scr.y, scr.x, 0.5f * scr.y), "No"))
                {

                }
            }
            else
            {
                if (GUI.Button(new Rect(14.5f * scr.x, 8f * scr.y, scr.x, 0.5f * scr.y), "Bye"))
                {
                    index = 0;
                    showDlg = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Movement.canMove = true;
                }
            }
        }
       
    }
}
