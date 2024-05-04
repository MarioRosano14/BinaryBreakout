using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomMove : MonoBehaviour
{
    private bool inRange = false;
    private Collider playerCollider;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            inRange = true;
            playerCollider = other;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            inRange = false;
        }
    }

    private void Update() {
        if (inRange) {
            if (Input.GetKeyDown(KeyCode.E)) {
                GameObject player = playerCollider.gameObject;
                Player data = player.GetComponent<Player>();
                if (data.scene == 1) {
                    data.scene = 2;
                    SceneManager.LoadScene("Pruebas");
                }
                else if (data.scene == 2) {
                    data.scene = 3;
                    SceneManager.LoadScene("dasdasdw");
                }
                // etc
            }
        }
    }

    public void ChangeRoom() {
        GameObject player = GameObject.FindWithTag("Player");
        /*
        if (data.scene == 0) {
                data.scene = 1;
                SceneManager.LoadScene("asdasd");
            }
        else if (data.scene == 1) {
            data.scene = 2;
            SceneManager.LoadScene("dasdasdw");
        }*/
    }
}