using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public GameObject canvas;
    public Button resumeButton;
    public Button saveButton;
    public Button quitButton;
    public static bool inPause;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);

        resumeButton.onClick.AddListener(QuitMenu);
        saveButton.onClick.AddListener(SaveGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (canvas.activeSelf) {
                canvas.SetActive(false);
                inPause = false;

                if (Dialogue.inDialogue) {
                    Cursor.lockState = CursorLockMode.Locked;
                }

                Time.timeScale = 1f;
            }
            else {
                inPause = true;
                canvas.SetActive(true);

                if (Dialogue.inDialogue) {
                    Cursor.lockState = CursorLockMode.None;
                }

                Time.timeScale = 0f;
            }
        }
    }

    public void QuitMenu() {
        inPause = false;
        canvas.SetActive(false);

        if (Dialogue.inDialogue) {
            Cursor.lockState = CursorLockMode.Locked;
        }

        Time.timeScale = 1f;
    }

    public void SaveGame() {
        Debug.Log("Guardas partida");
    }

    public void QuitGame() {
        inPause = false;
        SceneManager.LoadScene("MenuInicial");
    }
}
