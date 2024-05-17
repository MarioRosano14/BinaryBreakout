using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenScript : MonoBehaviour
{
    private static HomeScreenScript instance;
    private Scene scene;

    void Start() {
        PlayerPrefs.SetInt("sceneInGame", 0);
        scene = SceneManager.GetSceneByName("MenuUI");
    }

    void Update() {
        if (scene.isLoaded) {
            if (Cursor.lockState == CursorLockMode.Locked) {
                Cursor.lockState = CursorLockMode.None;
            }

            if (!Cursor.visible) {
                Cursor.visible = true;
            }
        }
    }

    public void NewGame() {
        PlayerPrefs.SetInt("sceneInGame", 1);

        PlayerData data = new PlayerData();

        SaveSystem.SavePlayer(data);

        SceneManager.LoadScene("Despacho");
    }

    public void LoadScene() {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null) {
            PlayerPrefs.SetInt("sceneInGame", data.scene);

            switch(data.scene) {
                case 1: 
                    SceneManager.LoadScene("Despacho");
                    break;
                case 2:
                    SceneManager.LoadScene("Pasillo 1");
                    break;
                case 3:
                    SceneManager.LoadScene("Biblioteca");
                    break;
                case 4:
                    SceneManager.LoadScene("Pasillo 2");
                    break;
                case 5:
                    SceneManager.LoadScene("PingPong");
                    break;
                default:
                    break;
            }
        }
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
