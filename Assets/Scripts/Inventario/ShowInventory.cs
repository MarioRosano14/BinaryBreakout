using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject mainInventory;
    public GameObject QButton;
    public GameObject AButton;
    public GameObject DButton;
    public static bool inInventory = false;
    void Start()
    {
        mainInventory = GameObject.FindWithTag("MainInventory");
        mainInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuScript.inPause && !Dialogue.inDialogue) {
            if (Input.GetKeyDown(KeyCode.I)) {
                if (mainInventory.activeSelf) {
                    mainInventory.SetActive(false);
                    inInventory = false;

                    if (CamSwitch.inSpecial) QButton.SetActive(true);
                    if (!CamSwitch.inSpecial) AButton.SetActive(true);
                    if (!CamSwitch.inSpecial) DButton.SetActive(true);
                }
                else {
                    mainInventory.SetActive(true);
                    inInventory = true;

                    if (CamSwitch.inSpecial) QButton.SetActive(false);
                    if (!CamSwitch.inSpecial) AButton.SetActive(false);
                    if (!CamSwitch.inSpecial) DButton.SetActive(false);
                }
            }
        }
    }
}
