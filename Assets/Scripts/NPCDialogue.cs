using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{

    public List<string> dlg;

    public bool showDlg;

    public string[] dlgText;
    public string[] likeText;
    public string[] neutralText;
    public string[] dislikeText;

    public int approval;
    public void NextButton()
    {

    }
    public void Update()
    {
        approval = Mathf.Clamp(approval, -1, 1);

        switch (approval)
        {
            case -1:
                dlgText = dislikeText;
                break;
            case 0:
                dlgText = neutralText;
                break;
            case 1:
                dlgText = likeText;
                break;
        }
    }
}

