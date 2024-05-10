using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class CamZoom : MonoBehaviour, IPointerClickHandler
{
    private CamSwitch camSwitch;
    private bool zoomed = false;
    public static bool inInventory = false;
    public int camera;

    public GameObject QButton;
    public GameObject AButton;
    public GameObject DButton;

    public void Start() {
        QButton.SetActive(false);

        GameObject player = GameObject.FindWithTag("Player");
        camSwitch = player.GetComponent<CamSwitch>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        zoomed = true;
        camSwitch.changeSpecialCameras(camera);
        QButton.SetActive(true);
        AButton.SetActive(false);
        DButton.SetActive(false);
    }

    public void Update() {
        if (zoomed && Input.GetKeyDown(KeyCode.Q) && !inInventory) {
            zoomed = false;
            camSwitch.changeNormalCameras();
            QButton.SetActive(false);
            AButton.SetActive(true);
            DButton.SetActive(true);
        }
    }
}