using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject mainInventory;
    private CamSwitch camSwitch;
    public GameObject QButton;
    public GameObject AButton;
    public GameObject DButton;
    void Start()
    {
        mainInventory = GameObject.FindWithTag("MainInventory");
        mainInventory.SetActive(false);

        GameObject player = GameObject.FindWithTag("Player");
        camSwitch = player.GetComponent<CamSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            if (mainInventory.activeSelf) {
                mainInventory.SetActive(false);
                camSwitch.inInventory = false;
                CamZoom.inInventory = false;
                MovManecillas.inInventory = false;

                if (camSwitch.inSpecial) QButton.SetActive(true);
                if (!camSwitch.inSpecial) AButton.SetActive(true);
                if (!camSwitch.inSpecial) DButton.SetActive(true);
            }
            else {
                mainInventory.SetActive(true);
                camSwitch.inInventory = true;
                CamZoom.inInventory = true;
                MovManecillas.inInventory = true;

                if (camSwitch.inSpecial) QButton.SetActive(false);
                if (!camSwitch.inSpecial) AButton.SetActive(false);
                if (!camSwitch.inSpecial) DButton.SetActive(false);
            }
        }
    }
}
