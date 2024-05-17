using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menuScriptInLobby : MonoBehaviour
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

                Cursor.lockState = CursorLockMode.Locked;
            }
            else {
                inPause = true;
                canvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void QuitMenu() {
        inPause = false;
        canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void SaveGame() {
        inPause = false;
        canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.None;

        PlayerData data = new PlayerData();
        SaveSystem.SavePlayer(data);
    }

    public void QuitGame() {
        inPause = false;

        if (Dialogue.inDialogue) {
            Dialogue.inDialogue = false;
        }
        
        SceneManager.LoadScene("MenuUI");
    }
}
