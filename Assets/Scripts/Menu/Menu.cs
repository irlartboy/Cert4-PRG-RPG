using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("Village/Menu/Main menu")]
public class Menu : MonoBehaviour
{
    public GameObject apperancePanel;
    public GameObject classPanel;
    
    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void ExitToDesktop ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void ApperanceButton()
    {
        apperancePanel.SetActive(true);
        classPanel.SetActive(false);
    }
    public void ClassButton()
    {
        classPanel.SetActive(true);
        apperancePanel.SetActive(false);
    }
}
