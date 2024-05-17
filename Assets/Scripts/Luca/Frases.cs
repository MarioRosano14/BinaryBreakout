using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frases : MonoBehaviour
{
    private AudioSource aS;
    public AudioClip a1, a2, a3, a4, a5,
                     a6, a7, a8, a9, a10,
                     a11, a12, a13, a14;

    public float repeatInterval;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
        timer = repeatInterval;
    }

    void Update() {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (timer >= repeatInterval) {
            if (other.gameObject.tag == "Audio1") {
                aS.PlayOneShot(a1);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio2") {
                aS.PlayOneShot(a2);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio3") {
                aS.PlayOneShot(a3);
            }

            if (other.gameObject.tag == "Audio4") {
                aS.PlayOneShot(a4);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio5") {
                aS.PlayOneShot(a5);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio6") {
                aS.PlayOneShot(a6);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio7") {
                aS.PlayOneShot(a7);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio8") {
                aS.PlayOneShot(a8);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio9") {
                aS.PlayOneShot(a9);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio10") {
                aS.PlayOneShot(a10);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio11") {
                aS.PlayOneShot(a11);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio12") {
                aS.PlayOneShot(a12);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio13") {
                aS.PlayOneShot(a13);
                timer = 0f;
            }

            if (other.gameObject.tag == "Audio14") {
                aS.PlayOneShot(a14);
                timer = 0f;
            }
        }
    }
}
