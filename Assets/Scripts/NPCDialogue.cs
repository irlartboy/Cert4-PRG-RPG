using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCDialogue : MonoBehaviour
{

    public bool showDlg;

    public new string name;

    public DlgUI uI;

    public int index;
    public string[] dlgText;
    public string[] likeText;
    public string[] neutralText;
    public string[] dislikeText;

    public int approval;

    void Start()
    {
        uI.nameText.text = name;
    }
    public void OpenDLGWindow()
    {
        uI.dlgWindow.SetActive(true);
        showDlg = true;
        uI.dlgText.text = dlgText[index];

    }
    public void NextButton()
    {
        index++;
        uI.dlgText.text = dlgText[index];

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
[System.Serializable]
public class DlgUI
{

    public GameObject dlgWindow;

    public Text nameText;
    public Text dlgText;

}
