using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomMove : MonoBehaviour
{
    private bool inRange = false;
    private Player data;

    public Canvas canvas;

    public void Start() {
        canvas.gameObject.SetActive(false);
        data = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "BibliotecaTrigger" || other.gameObject.tag == "PingPongTrigger") {
            inRange = true;
            if (other.gameObject.tag == "BibliotecaTrigger" && data.scene == 2) {
                canvas.gameObject.SetActive(true);
            }
            else if (other.gameObject.tag == "PingPongTrigger" && data.scene == 4) {
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
                
                if (data.scene == 2) {
                    data.scene = 3;
                    SceneManager.LoadScene("Biblioteca");
                }
                else if (data.scene == 4) {
                    data.scene = 5;
                    SceneManager.LoadScene("PingPong");
                }
            }
        }
    }
}