using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour 
{
    public GameObject[] cameras;
    public GameObject[] specialCameras;
    private int cameraIndex = 0;
    private int lastSpecialCameraIndex;
    private bool inSpecial;

    public void Start() {
        for (int i = 0; i < cameras.Length; i++) {
            cameras[i].SetActive(false);
        }

        for (int i = 0; i < specialCameras.Length; i++) {
            specialCameras[i].SetActive(false);
        }

        inSpecial = false;
        cameras[0].SetActive(true);
    }

    public void Update() {
        if (!inSpecial) {
            if (Input.GetKeyDown(KeyCode.A)) {
                cameras[cameraIndex].SetActive(false);
                cameraIndex = (cameraIndex-1+cameras.Length)%cameras.Length;
                cameras[cameraIndex].SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                cameras[cameraIndex].SetActive(false);
                cameraIndex = (cameraIndex+1+cameras.Length)%cameras.Length;
                cameras[cameraIndex].SetActive(true);
            }
        }
    }

    public void changeSpecialCameras(int index) {
        inSpecial = true;
        cameras[cameraIndex].SetActive(false);
        specialCameras[index].SetActive(true);
        lastSpecialCameraIndex = index;
    }

    public void changeNormalCameras() {
        inSpecial = false;
        specialCameras[lastSpecialCameraIndex].SetActive(false);
        cameras[cameraIndex].SetActive(true);
    }
}