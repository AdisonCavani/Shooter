using Console;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour 
{
    public void ExitGame()
    {
        if (Application.isEditor)
        {
#if UNITY_EDITOR
            Debug.Log("Quitting game (button)...");
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else
        {
            Debug.Log("Quitting game (button)...");
            Application.Quit();
        }
    }
}
