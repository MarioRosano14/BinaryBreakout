using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class UIFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    public void Volver()
    {
        SceneManager.LoadScene("MenuUI");
    }

    // Update is called once per frame
    public void Salir()
    {
        #if UNITY_EDITOR
        // Salimos del modo de juego en el editor
        EditorApplication.isPlaying = false;
        #else
        // Salimos del juego
        Application.Quit();
        #endif
    }

}