using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class CamZoomDespacho : MonoBehaviour, IPointerClickHandler
{
    private CamSwitch camSwitch;
    private bool zoomed = false;
    public int camera;

    public GameObject QButton;
    public GameObject AButton;
    public GameObject DButton;

    private Collider collider;

    public void Start() {
        QButton.SetActive(false);
        collider = GetComponent<Collider>();

        GameObject player = GameObject.FindWithTag("Player");
        camSwitch = player.GetComponent<CamSwitch>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (!menuScript.inPause && !Dialogue.inDialogue) {
            zoomed = true;
            camSwitch.changeSpecialCameras(camera);
            QButton.SetActive(true);
            AButton.SetActive(false);
            DButton.SetActive(false);
            //collider.enabled = false;
        }
    }

    public void Update() {
        if (zoomed && Input.GetKeyDown(KeyCode.Q) && !ShowInventory.inInventory && !menuScript.inPause && !Dialogue.inDialogue) {
            zoomed = false;
            camSwitch.changeNormalCameras();
            QButton.SetActive(false);
            AButton.SetActive(true);
            DButton.SetActive(true);
        }
    }
}