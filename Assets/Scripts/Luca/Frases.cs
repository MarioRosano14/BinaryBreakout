using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frases : MonoBehaviour
{
    private AudioSource aS;
    public AudioClip a1, a2, a3, a4;
    
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Audio1") {
            aS.PlayOneShot(a1);
        }

        if (other.gameObject.tag == "Audio2") {
            aS.PlayOneShot(a2);
        }

        if (other.gameObject.tag == "Audio3") {
            aS.PlayOneShot(a3);
        }

        if (other.gameObject.tag == "Audio4") {
            aS.PlayOneShot(a4);
        }
    }
}
