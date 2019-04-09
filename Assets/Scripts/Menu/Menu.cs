using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("Village/Menu/Main menu")]
public class Menu : MonoBehaviour
{
   
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
}
