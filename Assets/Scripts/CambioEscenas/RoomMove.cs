using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomMove : MonoBehaviour
{
    private bool inRange = false;
    public Canvas canvas;

    public void Start() {
        canvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "BibliotecaTrigger" || other.gameObject.tag == "PingPongTrigger") {
            inRange = true;
            if (other.gameObject.tag == "BibliotecaTrigger" && PlayerPrefs.GetInt("sceneInGame", 0) == 2) {
                canvas.gameObject.SetActive(true);
            }
            else if (other.gameObject.tag == "PingPongTrigger" && PlayerPrefs.GetInt("sceneInGame", 0) == 4) {
                canvas.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "BibliotecaTrigger" || other.gameObject.tag == "PingPongTrigger") {
            inRange = false;
            canvas.gameObject.SetActive(false);
        }
    }

    private void Update() {
        if (inRange && !menuScriptInLobby.inPause) {

            if (Input.GetKeyDown(KeyCode.E)) {
                
                if (PlayerPrefs.GetInt("sceneInGame", 0) == 2) {
                    PlayerPrefs.SetInt("sceneInGame", 3);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    PlayerPosition.moved = false;
                    SceneManager.LoadScene("Biblioteca");
                }
                else if (PlayerPrefs.GetInt("sceneInGame", 0) == 4) {
                    PlayerPrefs.SetInt("sceneInGame", 5);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    PlayerPosition.moved = false;
                    SceneManager.LoadScene("PingPong");
                }
            }
        }
    }
}