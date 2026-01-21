using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : MonoBehaviour
{
    // This function is safe to call from a UI Button
    public void QuitGame()
    {
        Debug.Log("Quit button pressed");

#if UNITY_EDITOR
        // Stop Play Mode in the Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the built application
        Application.Quit();
#endif
    }
}
