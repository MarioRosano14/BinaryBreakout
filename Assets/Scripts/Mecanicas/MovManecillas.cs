using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovManecillas : MonoBehaviour
{
    public int minutes = 0;
    public int hour = 0;
	public int seconds = 0;

    public int wantedMinutes;
    public int wantedHour;
    public int wantedSeconds;

    private int selected;

    public GameObject pointerSeconds;
    public GameObject pointerMinutes;
    public GameObject pointerHours;
    public GameObject drawer;
    // Start is called before the first frame update
    void Start()
    {
        selected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuScript.inPause && !ShowInventory.inInventory && CamSwitch.inSpecial && !Dialogue.inDialogue) {

            if (Input.GetKeyDown(KeyCode.W)) {
                if (selected != 2) {
                    selected++;
                }
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                if (selected != 0) {
                    selected--;
                }
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                switch(selected) {
                    case 0:
                        hour = (hour+1)%24;
                        break;
                    case 1:
                        minutes = (minutes+1)%60;
                        break;
                    case 2:
                        seconds = (seconds+1)%60;
                        break;
                    default:
                        break;
                }

                //-- calculate pointer angles
                float rotationSeconds = (360.0f / 60.0f)  * seconds;
                float rotationMinutes = (360.0f / 60.0f)  * minutes;
                float rotationHours   = ((360.0f / 12.0f) * hour);

                //-- draw pointers
                pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
                pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
                pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                switch(selected) {
                    case 0:
                        hour--;
                        if (hour == -1) {
                            hour = 23;
                        }

                        break;
                    case 1:
                        minutes--;
                        if (minutes == -1) {
                            minutes = 59;
                        }

                        break;
                    case 2:
                        seconds--;
                        if (seconds == -1) {
                            seconds = 59;
                        }

                        break;
                    default:
                        break;
                }

                //-- calculate pointer angles
                float rotationSeconds = (360.0f / 60.0f)  * seconds;
                float rotationMinutes = (360.0f / 60.0f)  * minutes;
                float rotationHours   = ((360.0f / 12.0f) * hour);

                //-- draw pointers
                pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
                pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
                pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);
            }
            
            if (hour == wantedHour && minutes == wantedMinutes && seconds == wantedSeconds) {
                MoveDrawer();
            }
        }
    }

    public void MoveDrawer() {
        //drawer.transform = new Vector3();
        Debug.Log("Mover cajon");
    }
}
