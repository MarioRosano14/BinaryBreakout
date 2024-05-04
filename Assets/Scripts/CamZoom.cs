using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.EventSystems;

public class CamZoom : MonoBehaviour, IPointerClickHandler
{
    private CamSwitch camSwitch;
    private bool zoomed = false;
    public int camera;

    public void Start() {
        GameObject player = GameObject.FindWithTag("Player");
        camSwitch = player.GetComponent<CamSwitch>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        zoomed = true;
        camSwitch.changeSpecialCameras(camera);
    }

    public void Update() {
        if (zoomed && Input.GetKeyDown(KeyCode.Q)) {
            zoomed = false;
            camSwitch.changeNormalCameras();
        }
    }
}